using EdwardSFlores.Service.Controllers.V1.PublicApi;
using EdwardSFlores.Service.Services.Security.Jwt;
using Microsoft.AspNetCore.Mvc;

namespace EdwardSFlores.Service.Controllers.V1.PrivateApi;

[ApiController]
[Route("/v1/private-api/[controller]")]
public class PrivateCurriculumController : Controller
{
    [AuthorizeViaJwtV1]
    [HttpGet]
    public Curriculum GetStation()
    {
        return new Curriculum();
    }
}