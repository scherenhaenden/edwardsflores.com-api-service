using EdwardSFlores.Service.Controllers.V1.PublicApi;
using EdwardSFlores.Service.Services.Security.Jwt;
using Microsoft.AspNetCore.Mvc;

namespace EdwardSFlores.Service.Controllers.V1.PrivateApi;

[ApiController]
[Route("/v1/private-api/[controller]")]
public class UserAdministrationController : Controller
{
    [AuthorizeViaJwtV1]
    [HttpGet]
    [Route("user")]
    public object Profile(string token, string userId)
    {
        return new { token, userId };
    }
    
    /*[AuthorizeViaJwtV1]
    [HttpPut]
    public object Profile(object profile)
    {
        return new { profile };
    }
     
    [AuthorizeViaJwtV1]
    [HttpPut]
    public object UpdatePassword(object request)
    {
        return new { request };
    }*/
    
}