using Sodab.Abstracts.DomainAbstracts;

namespace Sodab.Domain;

public class User : IEntity, IAudited, IEnabled, ISoftDeleted
{
    public Guid Id { get; set; }

    public string? Name { get; set; }
    public string? Nickname { get; set; }
    public string? Email { get; set; }
    public string? Tel { get; set; }

    public FileResource? Avatar { get; set; }

    public string? Profile { get; set; }

    public Guid? CreateUserId { get; set; }
    public DateTime CreateTime { get; set; }
    public Guid? ModifyUserId { get; set; }
    public DateTime ModifyTime { get; set; }
    public bool IsEnabled { get; set; } = true;
    public bool IsDeleted { get; set; }
}