using PatternRepositoryUoW.API.Domain;

namespace PatternRepositoryUoW.API.Data.Repositories
{
    public interface IDepartmentRepository
    {
        Task<Department> GetByIdAsync(int id);
        void Add(Department department);
        bool Save();
    }
}
