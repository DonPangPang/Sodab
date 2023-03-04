namespace Sodab.Abstracts.DomainAbstracts;

public interface ICreator<T>
{
    T? CreateUserId { get; set; }

    DateTime CreateTime { get; set; }
}

public interface ICreator : ICreator<Guid?>
{
}