using School_Management_System.Models;
using School_Management_System.Repositories.GenericRepository;

namespace School_Management_System.Repositories.CoursesRepository
{
    public interface ICoursesRepository : IGenericRepository<Course>
    {
        public Task<List<Student>> StudentsInCourse(int id);
    }
}
