﻿using System.ComponentModel.DataAnnotations;

namespace CMS_CollegeManageSystem_.Models
{
    public class Teacher
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Name is required")]
        public string Name { get; set; }

        public string Image { get; set; }

        [Required(ErrorMessage = "Age is required")]
        public int Age { get; set; }

        [Required(ErrorMessage = "Sex is required")]
        public string Sex { get; set; }

        [Required(ErrorMessage = "Email is required")]
        [EmailAddress(ErrorMessage = "Invalid Email Address")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Phone is required")]
        [Phone(ErrorMessage = "Invalid Phone Number")]
        public string Phone { get; set; }

        public DateTime DateOfJoining { get; set; }

        public string Designation { get; set; }

        // A teacher can teach multiple subjects
        public ICollection<TeacherSubject> TeacherSubjects { get; set; }
    }
}
