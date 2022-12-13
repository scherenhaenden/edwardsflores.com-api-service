using EdwardSFlores.Service.Configuration.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;

namespace EdwardSFlores.Service.Controllers.V1.PublicApi;

[ApiController]
[Route("/v1/public-api/[controller]")]
public class CurriculumController : Controller
{
    private readonly IOptions<ConfigurationOfApplication> _options;

    public CurriculumController(IOptions<ConfigurationOfApplication> options)
    {
        _options = options;
    }
    
    [AllowAnonymous]
    [HttpGet]
    public Curriculum GetStation()
    {
        return new Curriculum();
    }
    
    [AllowAnonymous]

    [HttpGet]
    [Route("Config")]
    public async Task<IActionResult> Config()
    {
       // object to json
         var json = JsonConvert.SerializeObject(_options.Value);
        
        
        return Ok(json);
        
     

    }
}

// Create Curriculum model
public class Curriculum
{
    public string Name { get; set; }
    public string Description { get; set; }
    public string ImageUrl { get; set; }
    public string Url { get; set; }
}