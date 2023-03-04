namespace Sodab.Abstracts.DomainAbstracts;

public interface IEntity : IEntity<Guid>
{
    new Guid Id { get; set; }
}

public interface IEntity<T>
{
    T Id { get; set; }
}