using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.Extensions.DependencyInjection;
using Sodab.Abstracts.DomainAbstracts;
using Sodab.Abstracts.ViewModelAbstracts;
using Sodab.Attributes;
using Sodab.Framework.Common;
using Sodab.Framework.DbContexts;

namespace Sodab.Framework.Services;

[Service(ServiceLifetime.Scoped)]
public class SodabCrudService<TDbContext, TEntity> : SodabCrudService<TDbContext, Guid, TEntity>
    where TEntity : class, IEntity where TDbContext : DbContext
{
}

[Service(ServiceLifetime.Scoped)]
public class SodabCrudService<TDbContext, TKey, TEntity> : SodabServiceBase<TDbContext>, ISodabCrudService<TDbContext, TKey, TEntity>
    where TEntity : class, IEntity<TKey> where TDbContext : DbContext
{
    public async Task<IEnumerable<TEntity>> GetListAsync()
    {
        return await Query<TEntity>().ToListAsync();
    }

    public async Task<TEntity?> GetEntityByIdAsync(TKey id)
    {
        return await Query<TEntity>().FirstOrDefaultAsync(x => x.Id!.Equals(id));
    }

    public async Task<IEnumerable<TEntity?>> GetEntityByIdAsync(IEnumerable<TKey> ids)
    {
        return await Query<TEntity>().Where(x => ids.Contains(x.Id!)).ToListAsync();
    }

    public async Task AddEntityAsync(TEntity entity)
    {
        await Db.AddAsync(entity);

        await SaveChangeAsync();
    }

    public async Task AddEntityAsync(IEnumerable<TEntity> entities)
    {
        await Db.AddRangeAsync(entities);

        await SaveChangeAsync();
    }

    public async Task UpdateEntityAsync(TEntity entity)
    {
        Db.Update(entity);
        await SaveChangeAsync();
    }

    public async Task UpdateEntityAsync(IEnumerable<TEntity> entities)
    {
        Db.UpdateRange(entities);
        await SaveChangeAsync();
    }

    public async Task DeleteEntityById(TKey id)
    {
        var entity = await GetEntityByIdAsync(id);

        if (entity is null) throw new Exception($"{id}不存在");

        await DeleteEntityAsync(entity);
    }

    public async Task DeleteEntityByIds(IEnumerable<TKey> ids)
    {
        // ReSharper disable once PossibleMultipleEnumeration
        var entities = await GetEntityByIdAsync(ids);

        // ReSharper disable once PossibleMultipleEnumeration
        if (entities is null || !entities.Any()) throw new Exception($"{string.Join(",", ids.ToList())}不存在");

        // ReSharper disable once PossibleMultipleEnumeration
        await DeleteEntityAsync(entities!);
    }

    public async Task DeleteEntityAsync(TEntity entity)
    {
        Db.Remove(entity);

        await SaveChangeAsync();
    }

    public async Task DeleteEntityAsync(IEnumerable<TEntity> entities)
    {
        Db.RemoveRange(entities);

        await SaveChangeAsync();
    }
}