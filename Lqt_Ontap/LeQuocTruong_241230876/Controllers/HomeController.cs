using LeQuocTruong_241230876.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Diagnostics;

namespace LeQuocTruong_241230876.Controllers
{
    public class HomeController : Controller
    {
        private readonly QLNhaSachContext _context;

        public HomeController(QLNhaSachContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            ViewBag.TheLoai = _context.TheLoai.ToList();
            var sach = _context.Sach.Where(s => s.Gia >= 100).ToList();
            return View(sach);
        }
        [HttpGet]
        public IActionResult LocTheoTheLoai(int maTL)
        {
            var theLoai = _context.TheLoai.Find(maTL);
            if (theLoai == null)
                return NotFound();

            ViewBag.TieuDe = theLoai.TenTL;
            var sach = _context.Sach.Where(s => s.MaTL == maTL).ToList();
            return PartialView("LeQuocTruong_MainContent", sach);
        }

        [HttpGet]
        public IActionResult Create()
        {
            NapTheLoai();
            return View(new Sach());
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create([Bind("MaTL,TenSach,Gia,Anh")] Sach sach)
        {
            var theLoais = NapTheLoai();
            if (sach.MaTL > 0 && !theLoais.Any(t => t.MaTL == sach.MaTL))
                ModelState.AddModelError(nameof(Sach.MaTL), "Thể loại không tồn tại.");

            if (sach.Gia is decimal gia && gia != decimal.Truncate(gia))
                ModelState.AddModelError(nameof(Sach.Gia), "Hãy nhập giá theo số nguyên nghìn đồng.");

            if (!ModelState.IsValid)
                return View(sach);

            _context.Sach.Add(sach);
            _context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }

        private List<TheLoai> NapTheLoai()
        {
            var theLoais = _context.TheLoai.ToList();
            ViewBag.TheLoai = theLoais;
            ViewBag.DanhSachTheLoai = new SelectList(theLoais, nameof(TheLoai.MaTL), nameof(TheLoai.TenTL));
            return theLoais;
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
