using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using School_Management_System.DTOs.CoursesDTOs;
using School_Management_System.Models;
using School_Management_System.Repositories.CoursesRepository;

namespace School_Management_System.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CoursesController : ControllerBase
    {
        private readonly ICoursesRepository _couresRepo;

        public CoursesController(ICoursesRepository couresRepo)
        {
            _couresRepo = couresRepo;
        }

        //GET: api/Courses
        [HttpGet]
        public async Task<IActionResult> GetAllCourses()
        {
            return Ok(await _couresRepo.GetAllAsync());
        }
        //GET api/Courses/{id}
        [HttpGet("{id}")]
        public async Task<IActionResult> GetCourseById([FromRoute]int id)
        {
            var course = await _couresRepo.GetByIdAsync(id);
            if (course == null)
            {
                return NotFound();
            }
            return Ok(course);
        }
        // GET api/Courses/StudentsInCourse{id}
        [HttpGet("/StudentsInCourse{id}")]
        public async Task<IActionResult> GetStudentsInCourse([FromRoute] int id)
        {
            var students = await _couresRepo.StudentsInCourse(id);
            if (students == null || !students.Any())
            {
                return NotFound($"No students found in course with id:{id}");
            }
            return Ok(students);
        }
        //DELETE: api/Course/{id}
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCoures([FromRoute]int id)
        {
            _couresRepo.DeleteAsync(id);
            return Ok($"Course of id:{id} has been deleted successfully!");
        }
        //POST: api/Courses
        [HttpPost]
        public async Task<IActionResult> CreateCourse([FromBody] CreateNewCourseDto createNewCourse)
        {
            var course = new Course()
            {
                CourseName = createNewCourse.CourseName,
                MaxCapacity = createNewCourse.MaxCapacity,
                RoomNumber = createNewCourse.RoomNumber,
                
            };
            await _couresRepo.AddAsync(course);

            return Ok("Course Created!");
        }
        //PUT: api/Courses/{id}
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateCourse([FromBody] UpdateCourseDto updateCourseDto, [FromRoute] int id)
        {
            var exist = await _couresRepo.FindEntityAsync(c => c.CourseId == id);

            if(!exist)
            {
                return NotFound($"Course with id:{id} does not exist!");
            }
            var course = new Course()
            {
                CourseName = updateCourseDto.CourseName,
                MaxCapacity = updateCourseDto.MaxCapacity,
                RoomNumber = updateCourseDto.RoomNumber
            };

            _couresRepo.UpdateAsync(course);
            return Ok($"Course with id:{id} has been updated successfully!");

        }


    }

}
