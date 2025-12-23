using System.ComponentModel.DataAnnotations;

namespace StudentManagementSystem.Models
{
    public class Student
    {
        public int Id { get; set; }

        [Required]
        [Display(Name = "Student Name")]
        public string FullName { get; set; }

        [Required]
        [Display(Name = "Student ID")]
        public string StudentNumber { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }

        public string Program { get; set; }
    }
}
