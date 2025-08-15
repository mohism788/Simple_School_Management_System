using System.ComponentModel.DataAnnotations;

namespace School_Management_System.DTOs.CoursesDTOs
{
    public class UpdateCourseDto
    {
        public string CourseName { get; set; }

        [RoomNumberFormat]
        public string RoomNumber { get; set; }

        [Range(10, 30, ErrorMessage = "Student capacity must be between 10 and 30")]
        public int MaxCapacity { get; set; }
    }
}
