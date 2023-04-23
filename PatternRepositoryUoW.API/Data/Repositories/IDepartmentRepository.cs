using PatternRepositoryUoW.API.Data.Repositories.Base;
using PatternRepositoryUoW.API.Domain;

namespace PatternRepositoryUoW.API.Data.Repositories
{
    public interface IDepartmentRepository : IGenericRepository<Department>
    {
        /*Task<Department> GetByIdAsync(int id);
        void Add(Department department);
        */
        //bool Save();
    }
}
