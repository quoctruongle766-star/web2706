using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using lqtlesson12lap6.Data;
using lqtlesson12lap6.Models;

namespace lqtlesson12lap6.Controllers
{
    public class LqtLearnerController : Controller
    {
        private readonly LqtSchoolContext db;

        public LqtLearnerController(LqtSchoolContext context)
        {
            db = context;
        }

        [HttpGet]
        [ActionName("Index")]
        [Route("Learner/Index")]
        [Route("Learner")]
        [Route("LqtLearner/Index")]
        [Route("LqtLearner")]
        [Route("")]
        public IActionResult LqtIndex(int? mid, string? keyword, int? pageIndex)
        {
            return View("Index", LqtGetLearners(mid, keyword, pageIndex));
        }

        [HttpGet]
        [ActionName("LearnerFilter")]
        public IActionResult LqtLearnerFilter(int? mid, string? keyword, int? pageIndex)
        {
            return PartialView("LqtLearnerTable", LqtGetLearners(mid, keyword, pageIndex));
        }

        private List<LqtLearner> LqtGetLearners(int? mid, string? keyword, int? pageIndex)
        {
            IQueryable<LqtLearner> lqtQuery = db.Learners.Include(l => l.Major);
            if (mid.HasValue)
            {
                lqtQuery = lqtQuery.Where(l => l.MajorID == mid.Value);
            }

            if (!string.IsNullOrEmpty(keyword))
            {
                lqtQuery = lqtQuery.Where(l => l.FirstMidName.ToLower().Contains(keyword.ToLower()));
            }

            ViewBag.LqtMid = mid;
            ViewBag.LqtKeyword = keyword;

            const int lqtPageSize = 3;
            int lqtPageCount = (int)Math.Ceiling(lqtQuery.Count() / (double)lqtPageSize);
            int lqtPage = pageIndex == null || pageIndex <= 0 ? 1 : pageIndex.Value;
            ViewBag.LqtPageCount = lqtPageCount;
            lqtQuery = lqtQuery.OrderBy(l => l.LearnerID)
                .Skip((lqtPage - 1) * lqtPageSize).Take(lqtPageSize);

            return lqtQuery.OrderBy(l => l.LearnerID).ToList();
        }

        [HttpGet]
        [ActionName("Create")]
        [Route("Learner/Create")]
        [Route("LqtLearner/Create")]
        public IActionResult LqtCreate()
        {
            ViewBag.MajorID = new SelectList(db.Majors, "MajorID", "MajorName");
            return View();
        }

        [HttpPost]
        [ActionName("Create")]
        [ValidateAntiForgeryToken]
        [Route("Learner/Create")]
        [Route("LqtLearner/Create")]
        public IActionResult LqtCreate([Bind("FirstMidName,LastName,MajorID,EnrollmentDate")] LqtLearner learner)
        {
            if (ModelState.IsValid)
            {
                db.Learners.Add(learner);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.MajorID = new SelectList(db.Majors, "MajorID", "MajorName", learner.MajorID);
            return View(learner);
        }

        [HttpGet]
        [ActionName("Edit")]
        [Route("Learner/Edit/{id?}")]
        [Route("LqtLearner/Edit/{id?}")]
        public IActionResult LqtEdit(int? id)
        {
            if (id == null || db.Learners == null)
            {
                return NotFound();
            }

            var learner = db.Learners.Find(id);
            if (learner == null)
            {
                return NotFound();
            }

            ViewBag.MajorID = new SelectList(db.Majors, "MajorID", "MajorName", learner.MajorID);
            return View(learner);
        }

        [HttpPost]
        [ActionName("Edit")]
        [ValidateAntiForgeryToken]
        [Route("Learner/Edit/{id?}")]
        [Route("LqtLearner/Edit/{id?}")]
        public IActionResult LqtEdit(int id, [Bind("LearnerID,FirstMidName,LastName,MajorID,EnrollmentDate")] LqtLearner learner)
        {
            if (id != learner.LearnerID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    db.Update(learner);
                    db.SaveChanges();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!LqtLearnerExists(learner.LearnerID))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction("Index");
            }

            ViewBag.MajorID = new SelectList(db.Majors, "MajorID", "MajorName", learner.MajorID);
            return View(learner);
        }

        [HttpGet]
        [ActionName("Delete")]
        [Route("Learner/Delete/{id?}")]
        [Route("LqtLearner/Delete/{id?}")]
        public IActionResult LqtDelete(int? id)
        {
            if (id == null || db.Learners == null)
            {
                return NotFound();
            }

            var learner = db.Learners.Include(l => l.Major)
                .Include(e => e.Enrollments)
                .FirstOrDefault(m => m.LearnerID == id);

            if (learner == null)
            {
                return NotFound();
            }

            if (learner.Enrollments.Count() > 0)
            {
                return Content("This learner has some enrollments, can't delete!");
            }

            return View(learner);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [Route("Learner/Delete/{id?}")]
        [Route("LqtLearner/Delete/{id?}")]
        public IActionResult LqtDeleteConfirmed(int id)
        {
            if (db.Learners == null)
            {
                return Problem("Entity set 'Learners' is null.");
            }

            var learner = db.Learners.Find(id);
            if (learner != null)
            {
                db.Learners.Remove(learner);
                db.SaveChanges();
            }

            return RedirectToAction("Index");
        }

        private bool LqtLearnerExists(int id)
        {
            return (db.Learners?.Any(e => e.LearnerID == id)).GetValueOrDefault();
        }

    }
}

