using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace School_Management_System.Models
{
    public class Course
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int CourseId { get; set; }
        public string CourseName { get; set; }

        [RoomNumberFormat]
        public string RoomNumber { get; set; }

        [Range(10,30, ErrorMessage = "Student capacity must be between 10 and 30")]
        public int MaxCapacity { get; set; }

        public ICollection<Student> Students { get; set; } = new List<Student>();
    }
}
