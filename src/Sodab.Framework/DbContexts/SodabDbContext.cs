using System.Reflection;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Sodab.Abstracts.DomainAbstracts;

namespace Sodab.Framework.DbContexts;

public class SodabDbContext : DbContext
{
    public SodabDbContext(DbContextOptions<SodabDbContext> options) : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        var types = Assembly.GetExecutingAssembly().GetTypes().AsEnumerable()
            .Where(x => x is { IsInterface: false, IsAbstract: false } && x.IsAssignableTo(typeof(IEntityBase)));

        foreach (var type in types)
        {
            if (modelBuilder.Model.FindEntityType(type) is null)
            {
                modelBuilder.Model.AddEntityType(type);
            }
        }

        base.OnModelCreating(modelBuilder);
    }

    public override int SaveChanges()
    {
        try
        {
            AutoSetChangedEntities();
            return base.SaveChanges();
        }
        catch (DbUpdateException ex)
        {
            LogDbEntityValidationException(ex);
            throw;
        }
        catch (Exception)
        {
            throw;
        }
    }

    public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = new CancellationToken())
    {
        try
        {
            AutoSetChangedEntities();
            return base.SaveChangesAsync(cancellationToken);
        }
        catch (DbUpdateException ex)
        {
            LogDbEntityValidationException(ex);
            throw;
        }
        catch (Exception)
        {
            throw;
        }
    }

    private void AutoSetChangedEntities()
    {
        foreach (var dbEntityEntry in ChangeTracker.Entries<IEntity>())
        {
            var baseEntity = dbEntityEntry.Entity;
            switch (dbEntityEntry.State)
            {
                case EntityState.Added:
                    if (baseEntity is ICreator creatorEntity)
                    {
                        creatorEntity.CreateTime = DateTime.Now;
                    }
                    break;

                case EntityState.Modified:
                    if (baseEntity is IModified modifiedEntity)
                    {
                        modifiedEntity.ModifyTime = DateTime.Now;
                    }
                    break;

                case EntityState.Deleted:
                    if (baseEntity is ISoftDeleted deletedEntity)
                    {
                        deletedEntity.IsDeleted = true;
                        dbEntityEntry.State = EntityState.Modified;
                    }
                    break;
            }
        }
    }

    protected virtual void LogDbEntityValidationException(DbUpdateException exception)
    {
        //var sb = new StringBuilder();
        //sb.AppendLine("There are some validation errors while saving changes in EntityFramework:");
        //foreach (var exceptionEntityValidationError in exception.Entries)
        //{
        //    sb.AppendLine($"\t{exceptionEntityValidationError.Entity.GetType().Name}");
        //    foreach (var dbValidationError in exceptionEntityValidationError.)
        //    {
        //        sb.AppendLine("\t\t" + dbValidationError.PropertyName + ": " + dbValidationError.ErrorMessage);
        //    }
        //}
        //Logging.Logger.Error(sb.ToString());
    }
}