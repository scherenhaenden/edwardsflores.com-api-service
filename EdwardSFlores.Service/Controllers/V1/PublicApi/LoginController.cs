using EdwardSFlores.BusinessLogic.Services.Login;
using EdwardSFlores.Service.Chaos;
using EdwardSFlores.Service.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace EdwardSFlores.Service.Controllers.V1.PublicApi;

[ApiController]
[Route("/v1/public-api/[controller]")]
public class LoginController : Controller
{
    private readonly ILoginBusinessLogic _loginBusinessLogic;

    public LoginController(ILoginBusinessLogic loginBusinessLogic)
    {
        _loginBusinessLogic = loginBusinessLogic;
    }
 
    
    // write post method. Allow anonymous. Accept Login model. Return Ok or BadRequest
    [HttpPost]
    [AllowAnonymous]
    public IActionResult Login([FromBody] Login model)
    {
        var result = _loginBusinessLogic.Login(model.Username, model.Password);
        if (result.IsAuthenticated || result.IsAuthenticated == false)
        
        {
            // call service to generate token
            var claims = new[]
            {
                "admin",
                "user"
            };
            
            // Create sample of JwtCreatorModel
            var jwtCreatorModel = new JwtCreatorModel(
                "1",
                "EdwardSFlores",
                "HnV8TZY30iTOdtVWJG8abWvB1GlOgJuQdb3OIsj+BXE9NZDy0t8W3TcNekrF+2d/1sFnWG4ZdcF2Luqm/hccMw==",
                "http://localhost:5000",
                "http://localhost:5000",
                1,
                claims,
                claims);
           
            
            JwtGenerator jwtGenerator = new JwtGenerator();
            return Ok(jwtGenerator.CreateToken(jwtCreatorModel));
          
        }
        return BadRequest();
    }
}

// create login model
public class Login
{
    public string Username { get; set; }
    public string Password { get; set; }
}