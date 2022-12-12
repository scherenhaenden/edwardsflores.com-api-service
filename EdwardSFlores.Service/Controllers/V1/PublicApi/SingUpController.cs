using EdwardSFlores.BusinessLogic.Services.SingUp;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace EdwardSFlores.Service.Controllers.V1.PublicApi;

[ApiController]
[Route("/v1/public-api/[controller]")]
public class SingUpController: Controller
{
    private readonly ISingUpServiceBusinessLogic _singUpServiceBusinessLogic;

    public SingUpController(ISingUpServiceBusinessLogic singUpServiceBusinessLogic)
    {
        _singUpServiceBusinessLogic = singUpServiceBusinessLogic;
    }
    
    [AllowAnonymous]
    [HttpPost]
    public async Task<IActionResult> SingUp([FromBody] SingUpModelBusinessLogic request)
    {
        var response = await _singUpServiceBusinessLogic.SingUp(request);
        if(response)
            return Ok(response);
        return BadRequest(response);

    }
}