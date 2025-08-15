using School_Management_System.DataAccess;
using School_Management_System.Models;
using School_Management_System.Repositories.GenericRepository;

namespace School_Management_System.Repositories.SuppliesRepository
{
    public class SuppliesRepository : GenericRepository<Supply>, ISuppliesRepository
    {
        public SuppliesRepository(SchoolDbContext context) : base(context)
        {
        }
    }
    
}
