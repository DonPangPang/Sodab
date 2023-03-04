using Microsoft.AspNetCore.Mvc;
using Sodab.Abstracts.DomainAbstracts;
using Sodab.Abstracts.ViewModelAbstracts;
using Sodab.Framework.Common;
using Sodab.Framework.Services;

namespace Sodab.Framework.Controllers;

[ApiController]
[Route("[Controller]/[Action]")]
public class ApiController : ControllerBase
{
}

[ApiController]
[Route("[Controller]/[Action]")]
public class ApiController<TEntity, TViewModel> : ApiController<Guid, TEntity, TViewModel> where TEntity : IEntityBase where TViewModel : IViewModel
{
}

[ApiController]
[Route("[Controller]/[Action]")]
public class ApiController<TKey, TEntity, TViewModel> : ApiController where TEntity : IEntityBase where TViewModel : IViewModel
{
    internal static ISodabCrudService<TEntity, TViewModel> Service => ServiceLocator.GetService<ISodabCrudService<TEntity, TViewModel>>();
}