using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Day13Lab4.Data;
using Day13Lab4.Models;

namespace Day13Lab4.Controllers
{
    public class LearnerController : Controller
    {
        private SchoolContext db;
        public LearnerController(SchoolContext context)
        {
            db = context;
        }

        public IActionResult Index()
        {
            var learners = db.Learners.Include(m => m.Major).ToList();
            return View(learners);
        }
        public IActionResult Create()
        {
            // dùng 1 trong 2 cách để tạo SelectList gửi về View qua ViewBag để
            // hiển thị danh sách chuyên ngành (Majors)

            // var majors = new List<SelectListItem>(); // cách 1
            // foreach (var item in db.Majors)
            // {
            //     majors.Add(new SelectListItem { Text = item.MajorName, Value = item.MajorID.ToString() });
            // }
            // ViewBag.MajorID = majors;

            // cách 2
            ViewBag.MajorId = new SelectList(db.Majors, "MajorId", "MajorName");
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create([Bind("FirstMidName,LastName,MajorId,EnrollmentDate")] Learner learner)
        {
            if (ModelState.IsValid)
            {
                db.Learners.Add(learner);
                db.SaveChanges();
                return RedirectToAction(nameof(Index));
            }

            // //lại dùng 1 trong 2 cách tạo SelectList gửi về View để hiển thị danh sách Majors
            ViewBag.MajorId = new SelectList(db.Majors, "MajorId", "MajorName");
            return View(learner);
        }
        public IActionResult Edit(int id)
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

            ViewBag.MajorId = new SelectList(db.Majors, "MajorId", "MajorName", learner.MajorId);
            return View(learner);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, [Bind("LearnerId,FirstMidName,LastName,MajorId,EnrollmentDate")] Learner learner)
        {
            if (id != learner.LearnerId)
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
                    if (!LearnerExists(learner.LearnerId))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }

            ViewBag.MajorId = new SelectList(db.Majors, "MajorId", "MajorName", learner.MajorId);
            return View(learner);
        }

        private bool LearnerExists(int id)
        {
            return (db.Learners?.Any(e => e.LearnerId == id)).GetValueOrDefault();
        }
        public IActionResult Delete(int id)
        {
            if (id == null || db.Learners == null)
            {
                return NotFound();
            }

            var learner = db.Learners
                .Include(l => l.Major)
                .Include(e => e.Enrollments)
                .FirstOrDefault(m => m.LearnerId == id);

            if (learner == null)
            {
                return NotFound();
            }

            if (learner.Enrollments.Count > 0)
            {
                return Content("This learner has some enrollments, can't delete!");
            }

            return View(learner);
        }

        // POST: Learner/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            if (db.Learners == null)
            {
                return Problem("Entity set 'Learners' is null.");
            }

            var learner = db.Learners.Find(id);

            if (learner != null)
            {
                db.Learners.Remove(learner);
            }

            db.SaveChanges();
            return RedirectToAction(nameof(Index));
        }
    }
}
