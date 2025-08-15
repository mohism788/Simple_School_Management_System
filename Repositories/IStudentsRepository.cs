using School_Management_System.Models;
using School_Management_System.Repositories.GenericRepository;

namespace School_Management_System.Repositories
{
    public interface IStudentsRepository : IGenericRepository<Student>
    {

        Task<List<Course>> CoursesForStudent(int id);
    }
}
