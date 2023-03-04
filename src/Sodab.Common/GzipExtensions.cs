namespace Sodab.Common;

public static class GzipExtensions
{
    public static string Gzip(this string? source)
    {
        return string.Empty;
    }

    public static async Task<string> GzipAsync(this string? source)
    {
        throw new NotImplementedException();
    }

    public static string UnGzip(this string? source)
    {
        return string.Empty;
    }

    public static async Task<string> UnGzipAsync(this string? source)
    {
        throw new NotImplementedException();
    }
}