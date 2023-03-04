using Microsoft.Extensions.DependencyInjection;
using Sodab.Attributes;

namespace Sodab.Framework.Services;

[Service(ServiceLifetime.Scoped)]
public class SodabCrudService : ISodabCrudService
{
}