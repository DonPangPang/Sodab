using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using Sodab.Abstracts.DomainAbstracts;
using Sodab.Abstracts.ViewModelAbstracts;
using Sodab.Framework.DbContexts;

namespace Sodab.Framework.Services;

public interface ISodabCrudService<TDbContext, TEntity> : ISodabCrudService<TDbContext, Guid, TEntity>, ISodabServiceBase<TDbContext>
    where TEntity : IEntityBase where TDbContext : DbContext
{
}

public interface ISodabCrudService<TDbContext, in TKey, TEntity> : ISodabServiceBase<TDbContext>
    where TEntity : IEntityBase where TDbContext : DbContext
{
    Task<IEnumerable<TEntity>> GetListAsync();

    Task<TEntity?> GetEntityByIdAsync(TKey id);

    Task<IEnumerable<TEntity?>> GetEntityByIdAsync(IEnumerable<TKey> ids);

    Task AddEntityAsync(TEntity entity);

    Task AddEntityAsync(IEnumerable<TEntity> entities);

    Task UpdateEntityAsync(TEntity entity);

    Task UpdateEntityAsync(IEnumerable<TEntity> entities);

    Task DeleteEntityById(TKey id);

    Task DeleteEntityByIds(IEnumerable<TKey> ids);

    Task DeleteEntityAsync(TEntity entity);

    Task DeleteEntityAsync(IEnumerable<TEntity> entities);
}