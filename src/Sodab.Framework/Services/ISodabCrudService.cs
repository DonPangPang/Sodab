using Microsoft.EntityFrameworkCore.Storage;
using Sodab.Abstracts.DomainAbstracts;
using Sodab.Abstracts.ViewModelAbstracts;
using Sodab.Framework.DbContexts;

namespace Sodab.Framework.Services;

public interface ISodabCrudService<TEntity, TViewModel> : ISodabCrudService<Guid, TEntity, TViewModel> where TEntity : IEntityBase where TViewModel : IViewModel
{
}

public interface ISodabCrudService<TKey, TEntity, TViewModel> where TEntity : IEntityBase where TViewModel : IViewModel
{
}