using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using lqtlesson12lap5.Data;
using lqtlesson12lap5.Models;

namespace lqtlesson12lap5.Controllers
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
        public IActionResult LqtIndex(int? mid)
        {
            var lqtLearners = db.Learners.Include(l => l.Major).AsQueryable();
            if (mid != null)
            {
                lqtLearners = lqtLearners.Where(l => l.MajorID == mid);
            }
            return View("Index", lqtLearners.ToList());
        }

        [HttpGet]
        [ActionName("LearnerByMajorID")]
        public IActionResult LqtLearnerByMajorID(int mid)
        {
            var lqtLearners = db.Learners.Where(l => l.MajorID == mid)
                .Include(l => l.Major).ToList();
            return PartialView("LqtLearnerTable", lqtLearners);
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

