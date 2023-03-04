using Sodab.Abstracts.DomainAbstracts;

namespace Sodab.Blog.Domain;

public class Tag : IEntity, ICreator
{
    public Guid Id { get; set; }

    public string Name { get; set; } = null!;

    public ICollection<Weblog>? Weblogs { get; set; }

    public Guid? CreateUserId { get; set; }
    public DateTime CreateTime { get; set; }
}