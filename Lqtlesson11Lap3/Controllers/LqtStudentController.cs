using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Lqtlesson11Lap3.Models;

namespace Lqtlesson11Lap3.Controllers
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
                        Address = "A1-2018", Email = "nam@gmail.com", DateOfBorth = new DateTime(2003, 1, 1), Score = 8.5 },
                    new LqtStudent() { Id = 102, Name = "Minh Tú", Branch = LqtBranch.BE,
                        Gender = LqtGender.Female, IsRegular = true,
                        Address = "A1-2019", Email = "tu@gmail.com", DateOfBorth = new DateTime(2003, 5, 12), Score = 9.0 },
                    new LqtStudent() { Id = 103, Name = "Hoàng Phong", Branch = LqtBranch.CE,
                        Gender = LqtGender.Male, IsRegular = false,
                        Address = "A1-2020", Email = "phong@gmail.com", DateOfBorth = new DateTime(2002, 10, 20), Score = 7.0 },
                    new LqtStudent() { Id = 104, Name = "Xuân Mai", Branch = LqtBranch.EE,
                        Gender = LqtGender.Female, IsRegular = false,
                        Address = "A1-2021", Email = "mai@gmail.com", DateOfBorth = new DateTime(2004, 7, 8), Score = 8.0 }
                };
            }
        }

        [HttpGet]
        [ActionName("Index")]
        [Route("Student/Index")]
        [Route("Student")]
        [Route("LqtStudent/Index")]
        [Route("LqtStudent")]
        public IActionResult LqtIndex()
        {
            return View(listStudents);
        }

        [HttpGet]
        [ActionName("Create")]
        [Route("Student/Create")]
        [Route("LqtStudent/Create")]
        public IActionResult LqtCreate()
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
        [ActionName("Create")]
        [Route("Student/Create")]
        [Route("LqtStudent/Create")]
        public IActionResult LqtCreate(LqtStudent s)
        {
            if (ModelState.IsValid)
            {
                s.Id = listStudents.Any() ? listStudents.Last().Id + 1 : 101;
                listStudents.Add(s);
                return View("Index", listStudents);
            }

            ViewBag.AllGenders = Enum.GetValues(typeof(LqtGender)).Cast<LqtGender>().ToList();
            ViewBag.AllBranches = new List<SelectListItem>()
            {
                new SelectListItem { Text = "IT", Value = "IT" },
                new SelectListItem { Text = "BE", Value = "BE" },
                new SelectListItem { Text = "CE", Value = "CE" },
                new SelectListItem { Text = "EE", Value = "EE" }
            };

            return View(s);
        }
    }
}
