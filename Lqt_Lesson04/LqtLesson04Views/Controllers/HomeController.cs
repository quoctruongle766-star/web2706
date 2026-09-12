using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using LqtLesson04Views.Models;
namespace LqtLesson04Views.Controllers;
public class HomeController : Controller
{
    public IActionResult Index() => View();
    public IActionResult Privacy() => View();
    public IActionResult About() => View();
    public IActionResult Error() => View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
}
