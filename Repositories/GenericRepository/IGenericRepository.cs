using System.Linq.Expressions;

namespace School_Management_System.Repositories.GenericRepository
{
    public interface IGenericRepository<T> where T : class
    {
        Task<List<T>> GetAllAsync();
        Task<T> GetByIdAsync(int id);

        Task AddAsync(T entity);

        void UpdateAsync(T entity);

        void DeleteAsync(int id);

        //find 
        Task<bool> FindEntityAsync(Expression<Func<T, bool>> predicate);
        void UpdateRangeAsync(IEnumerable<T> entities);
       // void DeleteRange(IEnumerable<int> ids);

    }
}
