using CMS_CollegeManageSystem_.Data;
using CMS_CollegeManageSystem_.Models;
using Microsoft.AspNetCore.Mvc;
using CMS_CollegeManageSystem_.ViewModel;
namespace CMS_CollegeManageSystem_.Controllers
{
    public class StudentController : Controller
    {
        private ApplicationDbContext _context;
        public StudentController(ApplicationDbContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            SortingLogics sortingLogics = new SortingLogics();

            List<Student> studlist = _context.Students.ToList();
            var sortedList = studlist
                .OrderBy(s => sortingLogics.IsAlphanumericClass(s.Class) ? 0 : 1)
                .ThenByDescending(s => sortingLogics.ExtractNumericValue(s.Class))
                .ThenBy(s => sortingLogics.ExtractAlphabeticPart(s.Class))
                .ToList();

            return View(studlist);
            // return View(sortedList);
        }
        //public IActionResult Index(string searchQuery)
        //{

        //    var studlist = _context.Students.AsQueryable();


        //    if (!string.IsNullOrEmpty(searchQuery))
        //    {
        //        studlist = studlist.Where(s => s.Name.Contains(searchQuery));
        //    }


        //    List<Student> studentList = studlist.ToList();

        //    return View(studentList);
        //}


        public IActionResult AddStudent()
        {

            var student = new Student(); 
            return View(student);
        }

        public IActionResult EditStudent(int id)
        {
            
            var student = _context.Students.FirstOrDefault(s => s.Id == id);

            if (student == null)
            {
                return NotFound(); 
            }

            return View("AddStudent", student); 
        }

        [HttpPost]
        public IActionResult StudentUpsert(Student student)
        {
                if (student.Id == 0)
                {


                    _context.Students.Add(student);
                }
                else
                {
                    var existingStudent = _context.Students.FirstOrDefault(s => s.Id == student.Id);
                    if (existingStudent != null)
                    {
                        existingStudent.Name = student.Name;
                        existingStudent.PhoneNumber = student.PhoneNumber;
                        existingStudent.EmailAddress = student.EmailAddress;
                        existingStudent.Age = student.Age;
                        existingStudent.Class = student.Class;
                    existingStudent.RollNumber = student.RollNumber;
                    existingStudent.Subject_id = student.Subject_id;
                }
            }
            

                _context.SaveChanges();
                return RedirectToAction("Index");
        }

        [HttpPost]
        public JsonResult DeleteStudent(int id)
        {
            var student = _context.Students.FirstOrDefault(s => s.Id == id);
            if (student != null)
            {
                _context.Students.Remove(student);
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
