
using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using School_Management_System.DataAccess;

namespace School_Management_System.Repositories.GenericRepository
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        private readonly SchoolDbContext _dbContext;
        private readonly DbSet<T> _dbSet;
        public GenericRepository(SchoolDbContext dbContext)
        {
            _dbContext = dbContext;
            _dbSet = _dbContext.Set<T>();   
        }

        public async Task AddAsync(T entity)
        {
            await _dbSet.AddAsync(entity);
            await _dbContext.SaveChangesAsync();
        }

        public void DeleteAsync(int id)
        {
            var entity = _dbSet.Find(id);
             _dbSet.Remove(entity);

             _dbContext.SaveChanges();
        }

        public async Task<bool> FindEntityAsync(Expression<Func<T,bool>> predicate)
        {
            return await _dbSet.AnyAsync(predicate);
        }

        public async Task<List<T>> GetAllAsync()
        {
            return await _dbSet.ToListAsync();
        }

        public async Task<T> GetByIdAsync(int id)
        {
            return await _dbSet.FindAsync(id);
        }

         public void RemoveRange(IEnumerable<int> ids)
        {
            _dbSet.RemoveRange(_dbSet.Where(e => ids.Contains((int)e.GetType().GetProperty("Id").GetValue(e, null))));

            _dbContext.SaveChanges();

        }

        public void UpdateAsync(T entity)
        {
            _dbSet.Update(entity);
            _dbContext.SaveChanges();
        }

        public void UpdateRangeAsync(IEnumerable<T> entities)
        {
            _dbSet.UpdateRange(entities);
            _dbContext.SaveChanges();
        }
    }
}
