using EdwardSFlores.BusinessLogic.Services.Administration.Roles;
using EdwardSFlores.DataAccess.Database.ContextManagement;
using EdwardSFlores.DataAccess.Database.Core.Domain;
using EdwardSFlores.DataAccess.Database.Core.Unities;
using EdwardSFlores.DataAccess.Database.Persistence.Unities.ServiceUnities;
using EdwardSFlores.DataAccess.Services.Private.AdministrationOfApplication;
using EdwardSFlores.Service.Services.Security.Jwt;
using Microsoft.AspNetCore.Mvc;

namespace EdwardSFlores.Service.Controllers.V1.PrivateApi;

[ApiController]
[Route("/v1/private-api/[controller]")]
public class AdminOrganizations : Controller
{
    private readonly IDataContextManager _dataContextManager;
    private readonly IGenericUnitOfWork _genericUnitOfWork;

    public AdminOrganizations(IDataContextManager dataContextManager)
    {
        _dataContextManager = dataContextManager;
        _genericUnitOfWork = dataContextManager.GenericUnityOfWork;
    }
    
    // GET Organizations
    [AuthorizeViaJwtV1]
    [HttpGet]
    [Route("get-organizations")]
    public IActionResult GetOrganizations()
    {
        var organizations = _genericUnitOfWork.Organizations.GetAll();
        return Ok(organizations);
    }
    
    // ADD Organization non async
    [AuthorizeViaJwtV1]
    [HttpPost]
    [Route("add-organization")]
    public IActionResult AddOrganization([FromBody] OrganizationDto organization)
    {
        Organization newOrganization = new()
        {
            Name = organization.Name,
            Description = organization.Description
        };
        
        //var entity = organization.MapObjToObj<Organization>();
        _genericUnitOfWork.Organizations.Add(newOrganization);
        _genericUnitOfWork.Save();
        return Ok(organization);
    }
    
    // Update Organization non async
    [AuthorizeViaJwtV1]
    [HttpPut]
    public IActionResult UpdateOrganization([FromBody] OrganizationDto organization)
    {
        var entity = organization.MapObjToObj<Organization>();
        _genericUnitOfWork.Organizations.Update(entity);
        _genericUnitOfWork.Save();
        return Ok(organization);
    }
    
    // Delete Organization non async
    [AuthorizeViaJwtV1]
    [HttpDelete]
    public IActionResult DeleteOrganization([FromBody] OrganizationDto organization)
    {
        var entity = organization.MapObjToObj<Organization>();
        _genericUnitOfWork.Organizations.Remove(entity);
        _genericUnitOfWork.Save();
        return Ok(organization);
    }
}


// create new model based in Organization
public class OrganizationDto
{
    public Guid? Guid { get; set; }
    public DateTime? InsertedDate { get; set; }
    public DateTime? UpdatedDate { get; set; }
    public bool? IsActive { get; set; } = true;
    public string Name { get; set; }
    public string? Description { get; set; }
    public string? Address { get; set; }
    public string? City { get; set; }
    public string? State { get; set; }
    public string? ZipCode { get; set; }
    public string? Phone { get; set; }
    public string? Email { get; set; }
    public string? Website { get; set; }
}