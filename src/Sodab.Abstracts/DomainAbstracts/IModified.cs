namespace Sodab.Abstracts.DomainAbstracts;

public interface IModified<T>
{
    T? ModifyUserId { get; set; }

    DateTime ModifyTime { get; set; }
}

public interface IModified : IModified<Guid?>
{
}