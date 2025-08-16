using System.Linq.Expressions;

namespace School_Management_System.Repositories.GenericRepository
{
    public interface IGenericRepository<T> where T : class
    {
        Task<List<T>> GetAllAsync();
        Task<T> GetByIdAsync(int id);

        Task AddAsync(T entity);

        Task UpdateAsync(T entity);

        Task DeleteAsync(int id);

        //find 
        Task<bool> FindEntityAsync(Expression<Func<T, bool>> predicate);
        Task UpdateRangeAsync(IEnumerable<T> entities);
       

    }
}
