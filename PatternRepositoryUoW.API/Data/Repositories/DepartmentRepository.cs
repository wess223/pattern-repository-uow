using Microsoft.EntityFrameworkCore;
using PatternRepositoryUoW.API.Domain;

namespace PatternRepositoryUoW.API.Data.Repositories
{
    public class DepartmentRepository : IDepartmentRepository
    {
        private readonly ApplicationContext _context;
        public DepartmentRepository(ApplicationContext context)
        {
            _context = context;
        }

        public void Add(Department department)
        {
            _context.Departments.Add(department);
        }

        public async Task<Department> GetByIdAsync(int id)
        {
            return await _context.Departments.Include(c => c.Collaborators).FirstOrDefaultAsync(x => x.Id == id);
        }

        public bool Save()
        {
            return _context.SaveChanges() > 0;
        }
    }
}
