using Microsoft.EntityFrameworkCore;
using School_Management_System.DataAccess;
using School_Management_System.Models;
using School_Management_System.Repositories.GenericRepository;

namespace School_Management_System.Repositories.CoursesRepository
{
    public class CoursesRepository : GenericRepository<Course>, ICoursesRepository
    {
        private readonly SchoolDbContext _dbContext;

        public CoursesRepository(SchoolDbContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<List<Student>> StudentsInCourse(int id)
        {
            return await _dbContext.Courses
               .Where(c => c.CourseId == id)
               .SelectMany(c => c.Students) // If using EF Core 5+ implicit many-to-many
               .ToListAsync();
        }
    }
}
