using Microsoft.EntityFrameworkCore;

namespace Sodab.Framework.DbContexts;

public class SodabDbContext : DbContext
{
    public SodabDbContext(DbContextOptions<SodabDbContext> options) : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
    }
}