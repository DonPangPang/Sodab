namespace Sodab.Abstracts.DomainAbstracts;

public interface IEntityBase
{
}

public interface IEntity : IEntity<Guid>, IEntityBase
{
    new Guid Id { get; set; }
}

public interface IEntity<T> : IEntityBase
{
    T Id { get; set; }
}