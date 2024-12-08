using System.ComponentModel.DataAnnotations;

namespace CMS_CollegeManageSystem_.Models
{
    public class Student
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Name is required")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Age is required")]
        [Range(1, 50, ErrorMessage = "Age must be between 1 and 50")]
        public int Age { get; set; }

        public string? Image { get; set; }

        [Required(ErrorMessage = "Class is required")]
        public string Class { get; set; }

        [Required(ErrorMessage = "Roll Number is required")]
        public int RollNumber { get; set; }

        [Required(ErrorMessage = "Email Address is required")]
        [EmailAddress(ErrorMessage = "Invalid Email Address")]
        public string EmailAddress { get; set; }

        [Required(ErrorMessage = "Phone Number is required")]
        [Phone(ErrorMessage = "Invalid Phone Number")]
        [MaxLength(13)]
        public string PhoneNumber { get; set; }

        public int? Subject_id { get; set; }
       
    }
}