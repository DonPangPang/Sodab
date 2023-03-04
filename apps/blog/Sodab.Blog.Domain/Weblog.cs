using Microsoft.EntityFrameworkCore;
using Sodab.Abstracts.DomainAbstracts;
using Sodab.Common;

namespace Sodab.Blog.Domain;

public class Weblog : IEntity, IAudited
{
    public Guid Id { get; set; }

    public string Name { get; set; } = string.Empty;

    public Guid? CategoryId { get; set; }
    public Category? Category { get; set; }

    public ICollection<Tag>? Tags { get; set; }

    private const int MaxLength = 100;
    public string? Description => Content?[..MaxLength];

    private string? _content = string.Empty;

    [BackingField(nameof(_content))]
    public string? Content { get => _content.UnGzip(); set => _content = value.Gzip(); }

    public ICollection<Comment>? Comments { get; set; }

    public Guid? CreateUserId { get; set; }
    public DateTime CreateTime { get; set; }
    public Guid? ModifyUserId { get; set; }
    public DateTime ModifyTime { get; set; }
}