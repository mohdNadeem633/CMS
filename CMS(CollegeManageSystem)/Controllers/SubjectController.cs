using CMS_CollegeManageSystem_.Data;
using CMS_CollegeManageSystem_.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CMS_CollegeManageSystem_.Controllers
{
    public class SubjectController : Controller
    {
        private ApplicationDbContext _context;
        public SubjectController(ApplicationDbContext context)
        {
            _context = context;
            
        }
        public IActionResult Index()
        {
            var subject = _context.Subjects.ToList();
            return View(subject);
        }

        public IActionResult AddSubject()
        {
            var subject = new Subjects();
            return View(subject);
        }
        public IActionResult EditSubject(int id)
        {

            var subject = _context.Subjects.FirstOrDefault(s => s.Id == id);
            if (subject == null)
            {
                return NotFound();
            }
            return View("AddSubject", subject);
        }

        public IActionResult SubjectUpsert(Subjects subject)
        {

            if (subject.Id == 0)
            {
                _context.Subjects.Add(subject);
            }
            else
            {
                var existingStudent = _context.Subjects.FirstOrDefault(s => s.Id == subject.Id);
                if (existingStudent != null)
                {
                    existingStudent.Name = subject.Name;
                    existingStudent.Class = subject.Class;
                    existingStudent.Language = subject.Language;
                }
            }

            _context.SaveChanges();
            return RedirectToAction("Index");
        }


        [HttpPost]
        public JsonResult Delete(int id)
        {
            var subjects = _context.Subjects.FirstOrDefault(s => s.Id == id);
            if (subjects != null)
            {
                _context.Subjects.Remove(subjects);
                _context.SaveChanges();
                return Json(new { success = true });
            }

            return Json(new { success = false });
        }   

        [HttpGet]
        public IActionResult GetSubjects()
        {
            var subjects = _context.Subjects.ToList();
            return Json(subjects);
        }
    }
}
