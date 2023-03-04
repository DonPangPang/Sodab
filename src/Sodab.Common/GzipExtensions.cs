using System.IO.Compression;
using System.Text.RegularExpressions;
using System.Text;

namespace Sodab.Common;

public static class GzipExtensions
{
    public static string Gzip(this string? str)
    {
        if (string.IsNullOrEmpty(str) || str.Length == 0)
        {
            return "";
        }

        var data = Encoding.UTF8.GetBytes(str);

        using var ms = new MemoryStream();
        using (var gs = new GZipStream(ms, CompressionMode.Compress, true))
        {
            gs.Write(data, 0, data.Length);
            gs.Close();
        }

        return Convert.ToBase64String(ms.ToArray());
    }

    public static async Task<string> GzipAsync(this string? str)
    {
        if (string.IsNullOrEmpty(str) || str.Length == 0)
        {
            return "";
        }

        var data = Encoding.UTF8.GetBytes(str);

        using var ms = new MemoryStream();
        await using (var gs = new GZipStream(ms, CompressionMode.Compress, true))
        {
            await gs.WriteAsync(data, 0, data.Length);
            gs.Close();
        }

        return Convert.ToBase64String(ms.ToArray());
    }

    public static async Task<string> UnGzipAsync(this string? str)
    {
        if (string.IsNullOrEmpty(str) || str.Length == 0)
        {
            return "";
        }

        if (str.TrimStart().StartsWith("{"))
        {
            return str;
        }

        var data = Convert.FromBase64String(str);

        using var ms = new MemoryStream(data);
        await using var gs = new GZipStream(ms, CompressionMode.Decompress);
        using var outBuffer = new MemoryStream();

        var block = new byte[1024];
        while (true)
        {
            var read = await gs.ReadAsync(block, 0, block.Length);
            if (read <= 0)
            {
                break;
            }

            await outBuffer.WriteAsync(block, 0, read);
        }

        gs.Close();

        return Encoding.UTF8.GetString(outBuffer.ToArray());
    }

    public static string UnGzip(this string? str)
    {
        if (string.IsNullOrEmpty(str) || str.Length == 0)
        {
            return "";
        }

        if (str.TrimStart().StartsWith("{"))
        {
            return str;
        }

        var data = Convert.FromBase64String(str);

        using var ms = new MemoryStream(data);
        using var gs = new GZipStream(ms, CompressionMode.Decompress);
        using var outBuffer = new MemoryStream();

        var block = new byte[1024];
        while (true)
        {
            var read = gs.Read(block, 0, block.Length);
            if (read <= 0)
            {
                break;
            }

            outBuffer.Write(block, 0, read);
        }

        gs.Close();

        return Encoding.UTF8.GetString(outBuffer.ToArray());
    }

    private static bool IsBase64(string str)
    {
        String base64Pattern = "^([A-Za-z0-9+/]{4})*([A-Za-z0-9+/]{4}|[A-Za-z0-9+/]{3}=|[A-Za-z0-9+/]{2}==)$";
        return Regex.IsMatch(str, base64Pattern, RegexOptions.IgnoreCase);
    }
}