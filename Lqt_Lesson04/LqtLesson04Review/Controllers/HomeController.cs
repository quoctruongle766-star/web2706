using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using LqtLesson04Review.Models;
namespace LqtLesson04Review.Controllers;
public class HomeController : Controller
{
    public IActionResult Index() => View();
    public IActionResult Privacy() => View();
    public IActionResult Error() => View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
}
