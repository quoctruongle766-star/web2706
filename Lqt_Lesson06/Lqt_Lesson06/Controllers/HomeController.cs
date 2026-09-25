using Lqt_Lesson06.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace Lqt_Lesson06.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        } 
        public IActionResult Privacy()
        {
            return View();
        }

        public IActionResult LqtAbout()
        {
            return View();
        }

       
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
