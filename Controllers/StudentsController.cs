using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using School_Management_System.DataAccess;
using School_Management_System.Models;
using School_Management_System.NewFolder.DTOs;
using School_Management_System.Repositories;

namespace School_Management_System.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentsController : ControllerBase
    {
        private readonly IStudentsRepository _studentsRepo;

        public StudentsController(IStudentsRepository studentsRepo)
        {
            _studentsRepo = studentsRepo;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllStudents()
        {
            return Ok(await _studentsRepo.GetAllAsync());
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetStudentById(int id)
        {
            var student = await _studentsRepo.GetByIdAsync(id);
            if (student == null)
            {
                return NotFound();
            }
            return Ok(student);
        }


        [HttpGet("CoursesForStudent-{id}")]
        public async Task<IActionResult> GetCoursesForStudent(int id)
        {
            var courses = await _studentsRepo.CoursesForStudent(id);
            if (courses == null || !courses.Any())
            {
                return NotFound($"No courses found for student with id:{id}");
            }
            return Ok(courses);
        }

        [HttpPost]
        public async Task<IActionResult> CreateStudent([FromBody] CreateNewStudentDto newStudentDto)
        {
            var student = new Student
            {
                FullName = newStudentDto.FullName,
                Age = newStudentDto.Age,
                GradeLevel = newStudentDto.GradeLevel
            };
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            await _studentsRepo.AddAsync(student);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteStudent(int id)
        {
            _studentsRepo.DeleteAsync(id);
            return NoContent();
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateStudent(int id, [FromBody] UpdateStudentDto updatedStudentDto)
        {
            var student = await _studentsRepo.GetByIdAsync(id);
            if (student == null)
            {
                return NotFound();
            }
            student.FullName = updatedStudentDto.FullName;
            student.Age = updatedStudentDto.Age;
            student.GradeLevel = updatedStudentDto.GradeLevel;
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            _studentsRepo.UpdateAsync(student);
            return NoContent();
        }
    }
}
