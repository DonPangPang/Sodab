namespace Sodab.Abstracts.DomainAbstracts;

public interface IAudited : ICreator, IModified
{
}

public interface IAudited<T> : ICreator<T>, IModified<T>
{
}