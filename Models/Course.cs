using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace School_Management_System.Models
{
    public class Course
    {
        [Key] // Primary Key
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)] // Auto-increment
        public int CourseId { get; set; }
        public string CourseName { get; set; }

        [RoomNumberFormat] // Custom validation attribute 
        public string RoomNumber { get; set; }

        [Range(10,30, ErrorMessage = "Student capacity must be between 10 and 30")] // Range validation for MaxCapacity
        public int MaxCapacity { get; set; }

        public ICollection<Student> Students { get; set; } = new List<Student>();
    }
}
