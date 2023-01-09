using EdwardSFlores.BusinessLogic.Models;
using EdwardSFlores.BusinessLogic.Services.Technologies;
using EdwardSFlores.Service.Services.Security.Jwt;
using Microsoft.AspNetCore.Mvc;

namespace EdwardSFlores.Service.Controllers.V1.PrivateApi;

[ApiController]
[Route("/v1/private-api/[controller]")]
public class AdminTechnologiesController : Controller
{
    private readonly ITechnologyBusiness _technologyBusiness;

    public AdminTechnologiesController(ITechnologyBusiness technologyBusiness)
    {
        _technologyBusiness = technologyBusiness;
    }
    
    // create method httpget that get all technologies
    [AuthorizeViaJwtV1]
    [HttpGet]
    [Route("get-technologies")]
    public IActionResult GetAllTechnologies()
    {
        return Ok(_technologyBusiness.GetTechnologies());
    }
    
    // create method httppost to add new technology
    [AuthorizeViaJwtV1]
    [HttpPost]
    [Route("add-technology")]
    public IActionResult AddNewTechnology(TechnologyBusinessModel technoloy)
    {
        
        return Ok(_technologyBusiness.AddTechnology(technoloy));
    }
    
    // create method httpdelete to delete technology
    [AuthorizeViaJwtV1]
    [HttpDelete]
    [Route("delete-technology")]
    public IActionResult DeleteTechnology()
    {
        return Ok("Delete technology");
    }
    
    // create method httpput to update technology
    [AuthorizeViaJwtV1]
    [HttpPut]
    [Route("update-technology")]
    public IActionResult UpdateTechnology(TechnologyBusinessModel technoloy)
    {
        return Ok(_technologyBusiness.UpdateTechnology(technoloy));
    }
    
}