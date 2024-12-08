using CMS_CollegeManageSystem_.Data;
using CMS_CollegeManageSystem_.Models;
using CMS_CollegeManageSystem_.UnitOfwork.IUnitOfwork;
using Microsoft.AspNetCore.Mvc;
using System.Linq.Expressions;

namespace CMS_CollegeManageSystem_.Controllers
{
    public class TeacherController : Controller
    {
        private ICMSUnitOfWork _UnitOfWork;
        private readonly IWebHostEnvironment _WebHostEnvironment;
        public TeacherController(ICMSUnitOfWork unitOfWork, IWebHostEnvironment webHostEnvironment)
        {
            _UnitOfWork = unitOfWork;
                
        }
        public IActionResult Index()
        {

            List<Teacher> teacherls = _UnitOfWork.Teacher.GetAll(includeProperties: "Subject").ToList();
            return View(teacherls);

            //var teachers = _context.Teachers.ToList();
            //return View(teachers);
        }

        public IActionResult AddTeacher()
        {
            var teachers = new Teacher();
            return View(teachers);
        }
        public IActionResult EditTeacher(int id)
        {

            var teachers = _UnitOfWork.Teacher.Get(u => u.Id == id);
            if (teachers == null)
            {
                return NotFound();
            }
            return View("AddTeacher", teachers);
        }

        public IActionResult TeacherUpsert(Teacher Teacher)
        {

            if (Teacher.Id == 0)
            {
                _UnitOfWork.Teacher.Add(Teacher);

            }
            else
            {
                var existingTeacher = _UnitOfWork.Teacher.Get(u => u.Id == Teacher.Id);
                if (existingTeacher != null)
                {
                    existingTeacher.Name = Teacher.Name;
                    existingTeacher.Age = Teacher.Age;
                    existingTeacher.Sex = Teacher.Sex;
                    existingTeacher.DateOfJoining = Teacher.DateOfJoining;
                    existingTeacher.Designation = Teacher.Designation;
                    existingTeacher.Email = Teacher.Email;
                    existingTeacher.Image = Teacher.Image;
                    existingTeacher.Phone = Teacher.Phone;
                }
            }

                _UnitOfWork.Save();
            return RedirectToAction("Index");
        }

        [HttpPost]
        public JsonResult Delete(int id)
        {
            var teachers = _UnitOfWork.Teacher.Get(u => u.Id == id);
            if (teachers != null)
            {
                _UnitOfWork.Teacher.Remove(teachers);
                _UnitOfWork.Save();
                return Json(new { success = true });
            }

            return Json(new { success = false });
        }

        [HttpGet]
        public IActionResult GetSubjects()
        {
            var subjects = _UnitOfWork.Subject.GetAll();
            return Json(subjects);
        }
    }
}
