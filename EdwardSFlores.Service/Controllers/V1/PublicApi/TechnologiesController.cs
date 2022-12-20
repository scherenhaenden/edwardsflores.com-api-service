using Microsoft.AspNetCore.Mvc;

namespace EdwardSFlores.Service.Controllers.V1.PublicApi;

public class TechnologiesController : Controller
{
    // GET
    public IActionResult Index()
    {
        return View();
    }
}