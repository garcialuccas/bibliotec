using Microsoft.AspNetCore.Mvc;

namespace bibliotec.Controllers;

public class HomeController : Controller
{
    public IActionResult Index()
    {
        return View();
    }
}
