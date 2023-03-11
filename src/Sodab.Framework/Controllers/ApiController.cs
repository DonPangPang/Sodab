using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
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
public class ApiController<TDbContext, TEntity, TViewModel> : ApiController<TDbContext, Guid, TEntity, TViewModel>
    where TEntity : IEntityBase where TViewModel : IViewModel where TDbContext : DbContext
{
}

[ApiController]
[Route("[Controller]/[Action]")]
public class ApiController<TDbContext, TKey, TEntity, TViewModel> : ApiController where TEntity : IEntityBase where TViewModel : IViewModel where TDbContext : DbContext
{
    internal static ISodabCrudService<TDbContext, TKey, TEntity> Service => ServiceLocator.GetService<ISodabCrudService<TDbContext, TKey, TEntity>>();
}