using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace EdwardSFlores.Service.Controllers.V1.PrivateApi;

[ApiController]
[Route("/v1/public-api/[controller]")]
public class AdminArticlesController : Controller
{
    [AllowAnonymous]
    [HttpGet]
    [Route("get-article")]
    public IActionResult GetArticle()
    {
        return Ok("This is a public article");
    }
    
    [AllowAnonymous]
    [HttpGet]
    [Route("get-article-with-filters")]
    public IActionResult GetArticleWithFilters()
    {
        return Ok("This is a public article");
    }
}