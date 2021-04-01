using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using MP.Blazor.Demo.Core.Application.Contracts;
using MP.Blazor.Demo.Core.Domain.Common;
using MP.Blazor.Demo.Infrastructure.Contexts;

namespace MP.Blazor.Demo.Infrastructure.Repositories
{
    public class Repository<TEntity> : IRepository<TEntity>
        where TEntity : BaseEntity
    {
        protected readonly AppDbContext _dbContext;

        public Repository(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<TEntity> CreateAsync(
            TEntity entity,
            CancellationToken cancellationToken)
        {
            await _dbContext.Set<TEntity>()
                .AddAsync(entity, cancellationToken)
                .ConfigureAwait(false);

            await _dbContext
                .SaveChangesAsync(cancellationToken)
                .ConfigureAwait(false);

            return entity;
        }

        public virtual async Task<TEntity> ReadAsync(
            Guid id,
            CancellationToken cancellationToken)
        {
            return await _dbContext.Set<TEntity>()
                .FirstOrDefaultAsync(a => a.Id == id, cancellationToken)
                .ConfigureAwait(false);
        }

        public async Task UpdateAsync(
            TEntity entity,
            CancellationToken cancellationToken)
        {
            _dbContext
                .Entry(entity).State = EntityState.Modified;

            await _dbContext
                .SaveChangesAsync(cancellationToken)
                .ConfigureAwait(false);
        }

        public async Task DeleteAsync(
            TEntity entity,
            CancellationToken cancellationToken)
        {
            _dbContext.Set<TEntity>()
                .Remove(entity);

            await _dbContext
                .SaveChangesAsync(cancellationToken)
                .ConfigureAwait(false);
        }

        public async Task<IReadOnlyList<TEntity>> ListAllAsync(CancellationToken cancellationToken)
        {
            return await _dbContext.Set<TEntity>()
                .ToListAsync(cancellationToken)
                .ConfigureAwait(false);
        }

        public async Task<IReadOnlyList<TEntity>> ListAllAsync(
            int perPage,
            int page,
            CancellationToken cancellationToken)
        {
            return await _dbContext.Set<TEntity>()
                .Skip(perPage * (page - 1))
                .Take(perPage)
                .ToListAsync(cancellationToken)
                .ConfigureAwait(false);
        }
    }
}