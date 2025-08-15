using Microsoft.EntityFrameworkCore;
using School_Management_System.DataAccess;
using School_Management_System.Models;
using School_Management_System.Repositories.GenericRepository;

namespace School_Management_System.Repositories
{
    public class StudentsRepository : GenericRepository<Student>, IStudentsRepository
    {
        private readonly SchoolDbContext _dbContext;

        public StudentsRepository(SchoolDbContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<List<Course>> CoursesForStudent(int id)
        {
            return await _dbContext.Students
                .Where(x=>x.StudentId == id)
                .SelectMany(s => s.Courses)
                .ToListAsync();

        }
    }
}
