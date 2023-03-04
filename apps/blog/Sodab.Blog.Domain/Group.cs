using Sodab.Abstracts.DomainAbstracts;

namespace Sodab.Blog.Domain;

public class Category : IEntity
{
    public Guid Id { get; set; }
    public string Name { get; set; } = null!;

    public ICollection<Weblog>? Weblogs { get; set; }
}