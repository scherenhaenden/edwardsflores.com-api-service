using EdwardSFlores.BusinessLogic.Services.Login;
using EdwardSFlores.Service.Chaos;
using EdwardSFlores.Service.Configuration.Models;
using EdwardSFlores.Service.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;

namespace EdwardSFlores.Service.Controllers.V1.PublicApi;

[ApiController]
[Route("/v1/public-api/[controller]")]
public class LoginController : Controller
{
    private readonly ILoginBusinessLogic _loginBusinessLogic;
    private readonly ConfigurationOfApplication _appSettings;

    public LoginController(ILoginBusinessLogic loginBusinessLogic, IOptions<ConfigurationOfApplication> appSettings)
    {
        _loginBusinessLogic = loginBusinessLogic;
        _appSettings = appSettings.Value;
    }
 
    
    // write post method. Allow anonymous. Accept Login model. Return Ok or BadRequest
    [HttpPost]
    [AllowAnonymous]
    //[ProducesResponseType(typeof(LoginResponse), 200)]
    public IActionResult Login([FromBody] Login model)
    {
        var result = _loginBusinessLogic.Login(model.Username, model.Password);
        if (result != null && (result.IsAuthenticated || result.IsAuthenticated == false))
        
        {
            // call service to generate token
            var claims = new[]
            {
                "admin",
                "user"
            };
            
            var roles = new[]
            {
                "admin",
                "user"
            };

            //
                                                //= null, Dictionary<string, string>? roles = null
            // Create sample of JwtCreatorModel
            var jwtCreatorModel = new JwtCreatorModelV1(
                result.Guid.ToString(),
                result.Username,
                 _appSettings.Temporal.JwtSecret,
                "http://localhost:5000",
                "http://localhost:5000",
                100,
                claims,
                claims);
            
            // Create sample of JwtCreatorModel with JwtCreatorModelV2
            var jwtCreatorModelV2 = new JwtCreatorModelV1(
                result.Guid.ToString(),
                result.Username,
                _appSettings.Temporal.JwtSecret,
                "http://localhost:5000",
                "http://localhost:5000",
                100,
                claims,
                roles);
           
            
            var jwtManagementService = new JwtManagementService();
            var token= jwtManagementService.CreateToken(jwtCreatorModel);
            return Ok(new LoginResponse
            {
                IsAuthenticated = result.IsAuthenticated,
                Token = token
            });
            return Ok(jwtManagementService.CreateToken(jwtCreatorModel));
          
        }
        return BadRequest();
    }
    
    
    [HttpPost]
    [AllowAnonymous]
    [Route("new-password")]
    public IActionResult NewPassWord([FromBody] Login model)
    {
        var result = _loginBusinessLogic.NewPassword(model.Username, model.Password);
        
        return Ok();
    }
}

public class LoginResponse
{
    public bool IsAuthenticated { get; set; }
    public string Token { get; set; }
}

// create login model
public class Login
{
    public string Username { get; set; }
    public string Password { get; set; }
}