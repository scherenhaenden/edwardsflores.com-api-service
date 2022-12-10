using EdwardSFlores.DataAccess.Database.Core.Unities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace EdwardSFlores.Service.Controllers;

[ApiController]
[Route("[controller]")]
public class LoginController : Controller
{
    private readonly IUnitOfWork _unitOfWork;
    
    public LoginController(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }
    
    // write post method. Allow anonymous. Accept Login model. Return Ok or BadRequest
    [HttpPost]
    [AllowAnonymous]
    public IActionResult Login([FromBody] Login model)
    {
        if (model.Username == "admin" && model.Password == "admin")
        {
            return Ok();
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