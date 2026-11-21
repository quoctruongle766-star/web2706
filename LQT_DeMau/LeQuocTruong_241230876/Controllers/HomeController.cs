using LeQuocTruong_241230876.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace LeQuocTruong_241230876.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index([FromServices] QlHangHoaContext db)
        {
            var danhsach = db.HangHoa.Where(h => h.Gia >=100)
            .OrderBy(h => h.MaHang).ToList();
            return View(danhsach);
        }
        [HttpGet]
        public IActionResult ByLoai(int maLoai, [FromServices] QlHangHoaContext db)
        {
            var danhsach = db.HangHoa.Where(h => h.MaLoai == maLoai && h.Gia >= 100)
            .OrderBy(h => h.MaHang).ToList();
            return PartialView("HangHoaGrid", danhsach);
        }
        public IActionResult Privacy()
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
