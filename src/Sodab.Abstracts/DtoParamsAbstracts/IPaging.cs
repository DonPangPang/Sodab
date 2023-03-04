namespace Sodab.Abstracts.DtoParamsAbstracts;

public interface IPaging
{
    int Page { get; set; }
    int PageCount { get; set; }
}