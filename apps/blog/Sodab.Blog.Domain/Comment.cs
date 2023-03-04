using Sodab.Abstracts.DomainAbstracts;

namespace Sodab.Blog.Domain;

public class Comment : IEntity, IAudited, ISoftDeleted
{
    public Guid Id { get; set; }

    public Guid WeblogId { get; set; }
    public Weblog? Weblog { get; set; }

    public string Content { get; set; } = string.Empty;

    public Guid? ParentId { get; set; }

    public Guid? CreateUserId { get; set; }
    public DateTime CreateTime { get; set; }
    public Guid? ModifyUserId { get; set; }
    public DateTime ModifyTime { get; set; }
    public bool IsDeleted { get; set; }
}