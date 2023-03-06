using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.Extensions.DependencyInjection;
using Sodab.Abstracts.DomainAbstracts;
using Sodab.Attributes;
using Sodab.Framework.Common;
using Sodab.Framework.DbContexts;

namespace Sodab.Framework.Services;

[Service(ServiceLifetime.Scoped)]
public class SodabServiceBase<TDbContext> : ISodabServiceBase<TDbContext> where TDbContext : DbContext
{
    public static TDbContext DbContext => ServiceLocator.GetService<TDbContext>();

    public IQueryable<T> Query<T>() where T : class, IEntityBase
    {
        return DbContext.Set<T>();
    }

    public IDbContextTransaction BeginTransaction()
    {
        return DbContext.Database.BeginTransaction();
    }

    public async Task<IDbContextTransaction> BeginTransactionAsync()
    {
        return await DbContext.Database.BeginTransactionAsync();
    }

    public void CommitTransaction()
    {
        DbContext.Database.CommitTransaction();
    }

    public async Task CommitTransactionAsync()
    {
        await DbContext.Database.CommitTransactionAsync();
    }

    public int SaveChanges()
    {
        return DbContext.SaveChanges();
    }

    public async Task<int> SaveChangeAsync()
    {
        return await DbContext.SaveChangesAsync();
    }
}