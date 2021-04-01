using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using MP.Blazor.Demo.Core.Domain.Common;

namespace MP.Blazor.Demo.Core.Application.Contracts
{
    public interface IRepository<TEntity>
        where TEntity : BaseEntity
    {
        Task<TEntity> CreateAsync(
            TEntity entity,
            CancellationToken cancellationToken);

        Task<TEntity> ReadAsync(
            Guid id,
            CancellationToken cancellationToken);

        Task UpdateAsync(
            TEntity entity,
            CancellationToken cancellationToken);

        Task DeleteAsync(
            TEntity entity,
            CancellationToken cancellationToken);

        Task<IReadOnlyList<TEntity>> ListAllAsync(
            CancellationToken cancellationToken);

        Task<IReadOnlyList<TEntity>> ListAllAsync(
            int perPage,
            int page,
            CancellationToken cancellationToken);
    }
}