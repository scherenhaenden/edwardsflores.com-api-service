using EdwardSFlores.BusinessLogic.Services.Administration.Roles;
using EdwardSFlores.DataAccess.Services.Private.AdministrationOfApplication;
using EdwardSFlores.Service.Services.Security.Jwt;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Query.Internal;

namespace EdwardSFlores.Service.Controllers.V1.PrivateApi;

[ApiController]
[Route("/v1/public-api/[controller]")]
public class AdminRolesController : Controller
{
    private readonly IRolesBusinessLogic _rolesBusinessLogic;

    public AdminRolesController(IRolesBusinessLogic rolesBusinessLogic)
    {
        _rolesBusinessLogic = rolesBusinessLogic;
    }
    
    [AuthorizeViaJwtV1]
    [HttpGet]
    [Route("get-roles")]
    public IActionResult GetRoles()
    {
        return Ok(_rolesBusinessLogic.GetRoles());
    }
    
    [AuthorizeViaJwtV1]
    [HttpPost]
    [Route("create-role")]
    public IActionResult CreateRole(NewRoleApiModel roleApiModel)

    {
        var roleServiceModel = roleApiModel.MapObjToObj<RoleBusinessModel>();
        
        return Ok(_rolesBusinessLogic.AddRole(roleServiceModel));
    }
    
    [AuthorizeViaJwtV1]
    [HttpPut]
    [Route("update-role")]
    public IActionResult UpdateRole(RoleApiModel roleApiModel)
    {
        var roleServiceModel = roleApiModel.MapObjToObj<RoleBusinessModel>();
        
        return Ok(_rolesBusinessLogic.UpdateRole(roleServiceModel));
    }
}

public class NewRoleApiModel
{
    public string Name { get; set; }
    public string Description { get; set; }
}

public class RoleApiModel
{
    public Guid Guid { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
}