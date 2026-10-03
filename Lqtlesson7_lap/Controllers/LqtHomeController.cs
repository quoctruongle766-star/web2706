using Microsoft.AspNetCore.Mvc;
using Lqtlesson7_lap.Models;
using System.Diagnostics;

namespace Lqtlesson7_lap.Controllers;

public class LqtHomeController : Controller
{
    public IActionResult Index()
    {
        return View();
    }

    public IActionResult Error()
    {
        return View(new ErrorViewModel
        {
            RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier
        });
    }
}
