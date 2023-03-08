using System.Reflection;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Sodab.Attributes;
using Sodab.Framework.Common;

namespace Sodab.Framework.Extensions;

public static class SodabExtensions
{
    public static IServiceCollection AddServices(this IServiceCollection services)
    {
        var types = AppDomain.CurrentDomain
            .GetAssemblies()
            .SelectMany(x => x.GetTypes())
            .Where(t => t is { IsClass: true, IsAbstract: false }
                        && t.GetCustomAttributes(typeof(ServiceAttribute), false).Length > 0
            )
            .ToList();

        types.ForEach(impl =>
            {
                //获取该类所继承的所有接口
                var interfaces = impl.GetInterfaces();
                //获取该类注入的生命周期
                var lifetime = impl.GetCustomAttribute<ServiceAttribute>()?.LifeTime;

                interfaces.ToList().ForEach(i =>
                {
                    switch (lifetime)
                    {
                        case ServiceLifetime.Singleton:
                            services.AddSingleton(i, impl);
                            break;

                        case ServiceLifetime.Scoped:
                            services.AddScoped(i, impl);
                            break;

                        case ServiceLifetime.Transient:
                            services.AddTransient(i, impl);
                            break;
                    }
                });
            });

        return services;
    }

    public static IServiceCollection AddSodab(this IServiceCollection services)
    {
        services.AddServices();

        services.AddAutoMapper(config =>
        {
            config.AddMaps(AppDomain.CurrentDomain.GetAssemblies());
            config.RecognizePostfixes("ViewModel");
            config.RecognizeDestinationPostfixes("ViewModel");
        });

        return services;
    }

    public static IApplicationBuilder UseSodab(this IApplicationBuilder app)
    {
        ServiceLocator.Instance = app.ApplicationServices;

        return app;
    }
}