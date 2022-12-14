using EdwardSFlores.DataAccess.Database.Persistence.Repositories.ServiceRepositories.Users;
using EdwardSFlores.Service.Controllers.V1.PublicApi;
using EdwardSFlores.Service.Services.Security.Jwt;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace EdwardSFlores.Service.Controllers.V1.PrivateApi;

[ApiController]
[Route("/v1/private-api/[controller]")]
public class UserAdministrationController : Controller
{
    private readonly IUsersDataAccessDatabaseRepository _usersDataAccessDatabaseRepository;

    public UserAdministrationController(IUsersDataAccessDatabaseRepository usersDataAccessDatabaseRepository)
    {
        _usersDataAccessDatabaseRepository = usersDataAccessDatabaseRepository;
    }
    
    
    [AuthorizeViaJwtV1]
    [HttpGet]
    [Route("user")]
    public object Profile(string token, string userId)
    {
        return new { token, userId };
    }
    
    [AllowAnonymous]
    [HttpGet]
    [Route("test-user")]
    public object GetAll()
    {
        return _usersDataAccessDatabaseRepository.GetAll();
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