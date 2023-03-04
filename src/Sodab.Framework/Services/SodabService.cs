using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.Extensions.DependencyInjection;
using Sodab.Abstracts.DomainAbstracts;
using Sodab.Attributes;
using Sodab.Framework.DbContexts;

namespace Sodab.Framework.Services;

[Service(ServiceLifetime.Scoped)]
public class SodabService : ISodabService
{
    private readonly SodabDbContext _context;

    public SodabService(SodabDbContext context)
    {
        _context = context;
    }

    public IQueryable<T> Query<T>() where T : class, IEntityBase
    {
        return _context.Set<T>();
    }

    public IDbContextTransaction BeginTransaction()
    {
        return _context.Database.BeginTransaction();
    }

    public async Task<IDbContextTransaction> BeginTransactionAsync()
    {
        return await _context.Database.BeginTransactionAsync();
    }

    public void CommitTransaction()
    {
        _context.Database.CommitTransaction();
    }

    public async Task CommitTransactionAsync()
    {
        await _context.Database.CommitTransactionAsync();
    }

    public int SaveChanges()
    {
        return _context.SaveChanges();
    }

    public async Task<int> SaveChangeAsync()
    {
        return await _context.SaveChangesAsync();
    }
}