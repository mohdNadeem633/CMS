using System.ComponentModel.DataAnnotations;

namespace CMS_CollegeManageSystem_.Models
{
    public class Subjects
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Subject Name is required")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Class is required")]
        public string Class { get; set; }

        public string Language { get; set; }

        public ICollection<StudentSubject> StudentSubjects { get; set; }
        public ICollection<TeacherSubject> TeacherSubjects { get; set; }
    }

   
}
