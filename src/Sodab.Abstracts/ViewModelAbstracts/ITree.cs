namespace Sodab.Abstracts.ViewModelAbstracts;

public interface ITree<T> : ITree<Guid, T> where T : class
{
}

public interface ITree<TKey, T> where T : class
{
    public T? ParentId { get; set; }

    public IEnumerable<T>? Children { get; set; }
}