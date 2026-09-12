using Microsoft.AspNetCore.Mvc;
namespace LqtLesson04Review.Controllers;
public class LqtContactController : Controller
{
    public IActionResult Index()
    {
        ViewData["hoten"] = "Le Quoc Truong";
        ViewBag.age = "20++";
        TempData["email"] = "student@example.com";
        return View();
    }
}
