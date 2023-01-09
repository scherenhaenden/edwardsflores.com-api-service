using EdwardSFlores.BusinessLogic.Models;
using EdwardSFlores.BusinessLogic.Services.Technologies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace EdwardSFlores.Service.Controllers.V1.PublicApi;

[ApiController]
[Route("/v1/public-api/[controller]")]
public class TechnologiesController : Controller
{
    private readonly ITechnologyBusiness _technologyBusiness;

    public TechnologiesController(ITechnologyBusiness technologyBusiness)
    {
        _technologyBusiness = technologyBusiness;
    }
    
       
     [AllowAnonymous]
     [HttpGet]
     [Route("get-all")]
    public IActionResult Get()
    {
        return Ok(_technologyBusiness.GetTechnologies());
    }
    
    [AllowAnonymous]
    [HttpGet]
    [Route("add-tech")]
    public IActionResult Get(TechnologyBusinessModel model)
    {
        return Ok(_technologyBusiness.AddTechnology(model));
    }
}