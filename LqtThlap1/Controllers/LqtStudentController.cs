using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using LqtThlap1.Models;

namespace LqtThlap1.Controllers
{
    public class LqtStudentController : Controller
    {
        private static List<LqtStudent> listStudents = new List<LqtStudent>();

        public LqtStudentController()
        {
            if (listStudents.Count == 0)
            {
                listStudents = new List<LqtStudent>()
                {
                    new LqtStudent() { Id = 101, Name = "Hải Nam", Branch = LqtBranch.IT,
                        Gender = LqtGender.Male, IsRegular = true,
                        Address = "A1-2018", Email = "nam@g.com" },
                    new LqtStudent() { Id = 102, Name = "Minh Tú", Branch = LqtBranch.BE,
                        Gender = LqtGender.Female, IsRegular = true,
                        Address = "A1-2019", Email = "tu@g.com" },
                    new LqtStudent() { Id = 103, Name = "Hoàng Phong", Branch = LqtBranch.CE,
                        Gender = LqtGender.Male, IsRegular = false,
                        Address = "A1-2020", Email = "phong@g.com" },
                    new LqtStudent() { Id = 104, Name = "Xuân Mai", Branch = LqtBranch.EE,
                        Gender = LqtGender.Female, IsRegular = false,
                        Address = "A1-2021", Email = "mai@g.com" }
                };
            }
        }

        [HttpGet]
        [Route("Admin/Student/List", Name = "StudentList")]
        [Route("Student/Index")]
        [Route("Student")]
        [Route("LqtStudent/Index")]
        [Route("LqtStudent")]
        public IActionResult Index()
        {
            return View(listStudents);
        }

        [HttpGet]
        [Route("Admin/Student/Add", Name = "StudentCreate")]
        [Route("Student/Create")]
        [Route("LqtStudent/Create")]
        public IActionResult Create()
        {
            ViewBag.AllGenders = Enum.GetValues(typeof(LqtGender)).Cast<LqtGender>().ToList();

            ViewBag.AllBranches = new List<SelectListItem>()
            {
                new SelectListItem { Text = "IT", Value = "IT" },
                new SelectListItem { Text = "BE", Value = "BE" },
                new SelectListItem { Text = "CE", Value = "CE" },
                new SelectListItem { Text = "EE", Value = "EE" }
            };

            return View();
        }

        [HttpPost]
        [Route("Admin/Student/Add")]
        [Route("Student/Create")]
        [Route("LqtStudent/Create")]
        public IActionResult Create(LqtStudent s)
        {
            s.Id = listStudents.Any() ? listStudents.Last().Id + 1 : 101;
            listStudents.Add(s);
            return View("Index", listStudents);
        }
    }
}
