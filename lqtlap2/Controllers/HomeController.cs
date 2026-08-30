using Microsoft.AspNetCore.Mvc;

namespace Lab02_Controller.Controllers;

public class HomeController : Controller
{
    public IActionResult Index() => View();
}
