using System.ComponentModel.DataAnnotations;

namespace School_Management_System.NewFolder.DTOs
{
    public class UpdateStudentDto
    {
        public string FullName { get; set; }

        [Range(5, 18, ErrorMessage = "Student's Age must be between 5yo and 18yo")]
        public int Age { get; set; }

        [GradeFormat]
        public string GradeLevel { get; set; }
    }
}
