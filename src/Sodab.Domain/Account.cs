using Sodab.Abstracts.DomainAbstracts;

namespace Sodab.Domain;

public class Account : IEntity, IEnabled, ISoftDeleted
{
    public Guid Id { get; set; }

    public Guid UserId { get; set; }
    public User? User { get; set; }

    public string Username { get; set; } = null!;
    public string Password { get; set; } = null!;
    public bool IsEnabled { get; set; }
    public bool IsDeleted { get; set; }
}