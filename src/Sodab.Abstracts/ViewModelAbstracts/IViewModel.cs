namespace Sodab.Abstracts.ViewModelAbstracts;

public interface IViewModel : IViewModel<Guid>
{
}

public interface IViewModel<T>
{
    T Id { get; set; }
}