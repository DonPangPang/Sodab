using Sodab.Shared.Enums;

namespace Sodab.Shared;

public interface IResponseData<T>
{
    HttpCode Code { get; set; }
    public string? Message { get; set; }
    public T? Data { get; set; }
    public int TotalCount { get; set; }
}

public class SodabData : IResponseData<object>
{
    public HttpCode Code { get; set; }
    public string? Message { get; set; }
    public object? Data { get; set; }
    public int TotalCount { get; set; } = 0;
}

public class SodabData<T> : IResponseData<T>
{
    public HttpCode Code { get; set; }
    public string? Message { get; set; }
    public T? Data { get; set; }
    public int TotalCount { get; set; } = 0;
}