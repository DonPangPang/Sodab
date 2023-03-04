using Microsoft.Extensions.DependencyInjection;
using Sodab.Abstracts.DomainAbstracts;
using Sodab.Abstracts.ViewModelAbstracts;
using Sodab.Attributes;

namespace Sodab.Framework.Services;

[Service(ServiceLifetime.Scoped)]
public class SodabCrudService<TEntity, TViewModel> : SodabCrudService<Guid, TEntity, TViewModel>, ISodabCrudService<TEntity, TViewModel> where TEntity : IEntityBase where TViewModel : IViewModel
{
}

[Service(ServiceLifetime.Scoped)]
public class SodabCrudService<TKey, TEntity, TViewModel> : ISodabCrudService<TEntity, TViewModel> where TEntity : IEntityBase where TViewModel : IViewModel
{
}