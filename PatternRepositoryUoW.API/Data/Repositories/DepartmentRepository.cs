using Microsoft.EntityFrameworkCore;
using PatternRepositoryUoW.API.Data.Repositories.Base;
using PatternRepositoryUoW.API.Domain;

namespace PatternRepositoryUoW.API.Data.Repositories
{
    public class DepartmentRepository : GenericRepository<Department>, IDepartmentRepository
    {
        //private readonly ApplicationContext _context;
        //private readonly DbSet<Department> _dbSet;
        public DepartmentRepository(ApplicationContext context) : base(context)
        {
           // _context = context;
            //_dbSet = _context.Set<Department>();
        }

        /*
        public void Add(Department department)
        {
            _dbSet.Add(department);
        }

        public async Task<Department> GetByIdAsync(int id)
        {
            return await _dbSet.Include(c => c.Collaborators).FirstOrDefaultAsync(x => x.Id == id);
        }
        */

        //public bool Save()
        //{
        //    return _context.SaveChanges() > 0;
        //}
    }
}
