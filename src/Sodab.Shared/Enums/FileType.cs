namespace Sodab.Shared.Enums;

public enum FileType
{
    Unknown = 0,
    Image = 1,
    Video = 2,
    Markdown = 3,
}

public enum HttpCode
{
    /// <summary>
    /// 成功
    /// </summary>
    Success = 200,

    /// <summary>
    /// 失败
    /// </summary>
    Fail = 400,

    /// <summary>
    /// Token失效
    /// </summary>
    TokenExpired = 401,

    /// <summary>
    /// 错误
    /// </summary>
    Error = 500,
}