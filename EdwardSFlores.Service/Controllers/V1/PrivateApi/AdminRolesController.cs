using Microsoft.AspNetCore.Mvc;

namespace EdwardSFlores.Service.Controllers.V1.PrivateApi;

public class AdminRolesController : Controller
{
    // GET
    public IActionResult Index()
    {
        return View();
    }
}