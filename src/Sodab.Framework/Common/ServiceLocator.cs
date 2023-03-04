namespace Sodab.Framework.Common;

public static class ServiceLocator
{
    public static IServiceProvider Instance { get; set; } = null!;

    public static T GetService<T>()
    {
        return (T)Instance?.GetService(typeof(T))!;
    }
}