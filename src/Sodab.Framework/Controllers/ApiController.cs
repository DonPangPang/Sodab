using Microsoft.AspNetCore.Mvc;
using Sodab.Abstracts.DomainAbstracts;
using Sodab.Abstracts.ViewModelAbstracts;

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
}