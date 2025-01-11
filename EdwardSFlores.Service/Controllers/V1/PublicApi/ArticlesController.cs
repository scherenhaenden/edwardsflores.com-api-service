using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace EdwardSFlores.Service.Controllers.V1.PublicApi;

[ApiController]
[Route("/v1/public-api/[controller]")]
public class ArticlesController : Controller
{
    [AllowAnonymous]
    [HttpGet]
    [Route("get-article")]
    public IActionResult GetArticle()
    {
        return Ok(new { Message = "Hello from the public API!" });
    }
    
    [AllowAnonymous]
    [HttpGet]
    [Route("get-articles-page")]
    public IActionResult GetPageOfArticles()
    {
        return Ok(new { Message = "Hello from the public API!" });
    }
}