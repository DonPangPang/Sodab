using Microsoft.EntityFrameworkCore;
using Sodab.Framework.DbContexts;

namespace Sodab.Blog.WebApi.Data;

public class SodabBlogDbContext : SodabDbContext
{
    public SodabBlogDbContext(DbContextOptions<SodabDbContext> options) : base(options)
    {
    }
}