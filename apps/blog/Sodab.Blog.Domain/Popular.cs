using Sodab.Abstracts.DomainAbstracts;

namespace Sodab.Blog.Domain;

public class Popular : IEntity
{
    public Guid Id { get; set; }

    public Guid RelatedId { get; set; }

    public int Count { get; set; }
}