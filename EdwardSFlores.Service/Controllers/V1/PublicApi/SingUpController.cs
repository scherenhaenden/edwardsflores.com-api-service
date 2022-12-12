using EdwardSFlores.BusinessLogic.Services.SingUp;
using EdwardSFlores.Service.Configuration.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;

namespace EdwardSFlores.Service.Controllers.V1.PublicApi;

[ApiController]
[Route("/v1/public-api/[controller]")]
public class SingUpController: Controller
{
    private readonly ISingUpServiceBusinessLogic _singUpServiceBusinessLogic;
    private readonly IOptions<ConfigurationOfApplication> _options;

    // add options
    public SingUpController(ISingUpServiceBusinessLogic singUpServiceBusinessLogic, IOptions<ConfigurationOfApplication> options)

    {
        _singUpServiceBusinessLogic = singUpServiceBusinessLogic;
        _options = options;
    }
    
    [AllowAnonymous]
    [HttpPost]
    public async Task<IActionResult> SingUp([FromBody] SingUpModelBusinessLogic request)
    {
        try
        {
            var response = await _singUpServiceBusinessLogic.SingUp(request);
            if(response)
                return Ok(response);
            return BadRequest(response);       
        }
        catch (Exception e)
        {
            return BadRequest(_options.Value.DataAccess.DataBases.Global[0].ConnectionString);
        }
     

    }
    
    [AllowAnonymous]
    [HttpGet]
    public async Task<IActionResult> Config()
    {
       
            return Ok(_options.Value.DataAccess.DataBases.Global[0].ConnectionString);
        
     

    }
}