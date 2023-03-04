using Microsoft.EntityFrameworkCore.Storage;
using Sodab.Abstracts.DomainAbstracts;

namespace Sodab.Framework.Services;

public interface ISodabService
{
    IQueryable<T> Query<T>() where T : class, IEntityBase;

    IDbContextTransaction BeginTransaction();

    Task<IDbContextTransaction> BeginTransactionAsync();

    void CommitTransaction();

    Task CommitTransactionAsync();

    int SaveChanges();

    Task<int> SaveChangeAsync();
}