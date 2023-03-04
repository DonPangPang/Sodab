using Microsoft.Extensions.DependencyInjection;

namespace Sodab.Attributes;

[AttributeUsage(AttributeTargets.Class)]
public class ServiceAttribute : Attribute
{
    public ServiceLifetime LifeTime { get; set; }

    public ServiceAttribute(ServiceLifetime serviceLifetime = ServiceLifetime.Scoped)
    {
        LifeTime = serviceLifetime;
    }
}