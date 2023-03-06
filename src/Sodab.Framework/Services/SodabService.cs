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
    public static TDbContext Db => ServiceLocator.GetService<TDbContext>();

    public IQueryable<T> Query<T>() where T : class, IEntityBase
    {
        return Db.Set<T>();
    }

    public IDbContextTransaction BeginTransaction()
    {
        return Db.Database.BeginTransaction();
    }

    public async Task<IDbContextTransaction> BeginTransactionAsync()
    {
        return await Db.Database.BeginTransactionAsync();
    }

    public void CommitTransaction()
    {
        Db.Database.CommitTransaction();
    }

    public async Task CommitTransactionAsync()
    {
        await Db.Database.CommitTransactionAsync();
    }

    public int SaveChanges()
    {
        return Db.SaveChanges();
    }

    public async Task<int> SaveChangeAsync()
    {
        return await Db.SaveChangesAsync();
    }
}