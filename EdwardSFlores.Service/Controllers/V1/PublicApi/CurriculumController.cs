using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace EdwardSFlores.Service.Controllers.V1.PublicApi;

[ApiController]
[Route("/v1/public-api/[controller]")]
public class CurriculumController : Controller
{
    [AllowAnonymous]
    [HttpGet]
    public Curriculum GetStation()
    {
        return new Curriculum();
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