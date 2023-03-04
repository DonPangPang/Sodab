namespace Sodab.Abstracts.DomainAbstracts;

public interface IDeleted
{
    public bool IsDeleted { get; set; }
}

public interface ISoftDeleted : IDeleted
{
}