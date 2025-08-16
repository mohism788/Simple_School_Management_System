using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace School_Management_System.Models
{
    public class Student
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int StudentId { get; set; }

        [Required(ErrorMessage = "Full Name is required")]

        public string FullName { get; set; }


        [Range(5, 18, ErrorMessage = "Student's Age must be between 5yo and 18yo")]
        public int Age { get; set; }

        [GradeFormat] // Custom validation attribute for grade format
        public string GradeLevel { get; set; }
        // Navigation property for courses
        public ICollection<Course> Courses { get; set; } = new List<Course>();
        // Navigation property for supplies
        public ICollection<Supply> Supplies { get; set; } = new List<Supply>();


    }
}
