using System;
using System.Linq;
using System.Reflection;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Microsoft.EntityFrameworkCore;
using MP.Blazor.Demo.Core.Application.Contracts;
using MP.Blazor.Demo.Core.Domain.Common;
using Serilog;

namespace MP.Blazor.Demo.Infrastructure.Contexts
{
    public class AppDbContext : DbContext
    {
        private readonly IMediator _mediator;
        private readonly ILogger _logger;
        private readonly IUserService _userService;

        public AppDbContext(
            DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        public AppDbContext(
            DbContextOptions<AppDbContext> options,
            IMediator mediator,
            ILogger logger,
            IUserService userService) : base(options)
        {
            _mediator = mediator;
            _logger = logger;
            _userService = userService;
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder
                .RegisterAllEntities<BaseEntity>();

            modelBuilder
                .ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

            base.OnModelCreating(modelBuilder);
        }

        public override int SaveChanges()
        {
            return SaveChangesAsync()
                .GetAwaiter()
                .GetResult();
        }

        public override async Task<int> SaveChangesAsync(
            CancellationToken cancellationToken = new CancellationToken())
        {
            AuditEntity();

            int result = await base
                .SaveChangesAsync(cancellationToken)
                .ConfigureAwait(false);

            var entitiesWithEvents = ChangeTracker.Entries<DomainEvent>()
                .Select(e => e.Entity)
                //.Where(e => e.Events.Any())
                .ToArray();

            foreach (var entity in entitiesWithEvents)
            {
                await _mediator.Publish(entity, cancellationToken)
                    .ConfigureAwait(false);
            }

            return result;
        }

        private void AuditEntity()
        {
            var now = DateTime.Now;

            foreach (var entry in ChangeTracker.Entries<AuditableEntity>())
            {
                switch (entry.State)
                {
                    case EntityState.Added:
                        entry.CurrentValues[nameof(AuditableEntity.CreatedAt)] = now;
                        entry.CurrentValues[nameof(AuditableEntity.CreatedBy)] = _userService.Id;
                        entry.CurrentValues[nameof(AuditableEntity.UpdatedAt)] = now;
                        entry.CurrentValues[nameof(AuditableEntity.UpdatedBy)] = _userService.Id;
                        entry.CurrentValues[nameof(AuditableEntity.Version)] = (long)1;
                        break;

                    case EntityState.Modified:
                        entry.CurrentValues[nameof(AuditableEntity.UpdatedAt)] = now;
                        entry.CurrentValues[nameof(AuditableEntity.UpdatedBy)] = _userService.Id;
                        entry.CurrentValues[nameof(AuditableEntity.Version)] =
                            (long)entry.CurrentValues[nameof(AuditableEntity.Version)] + 1;
                        break;

                    case EntityState.Deleted:
                        entry.State = EntityState.Modified;
                        entry.CurrentValues[nameof(AuditableEntity.DeletedBy)] = _userService.Id;
                        entry.CurrentValues[nameof(AuditableEntity.DeletedAt)] = now;
                        entry.CurrentValues[nameof(AuditableEntity.Version)] =
                            (long)entry.CurrentValues[nameof(AuditableEntity.Version)] + 1;
                        break;

                    case EntityState.Detached or EntityState.Unchanged:
                        break;

                    default:
                        break;
                }
            }
        }
    }
}