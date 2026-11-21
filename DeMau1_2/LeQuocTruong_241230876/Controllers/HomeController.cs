using LeQuocTruong_241230876.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace LeQuocTruong_241230876.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index([FromServices] QLTaiSanContext db)
        {
            var danhsach = db.Set<TaiSan>().Where(x => x.NguyenGia >=20).OrderBy(x => x.MaTS).ToList();
            ViewData["TieuDe"] = "Lê Quốc Trưởng";
            return View(danhsach);
        }
        [HttpGet]
        public IActionResult ByLoai(int maLoai, [FromServices] QLTaiSanContext db)
        {
            var loai = db.Set<LoaiTaiSan>().Find(maLoai);
            if (loai == null)
            {
                return NotFound();
            }
            var danhsach = db.Set<TaiSan>().Where(x => x.MaLoai == maLoai).OrderBy(x => x.MaTS).ToList();
            ViewData["TieuDe"] = loai.TenLoai;
            return 
        PartialView("LeQuocTruong_DanhSachTaiSan", danhsach);
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
