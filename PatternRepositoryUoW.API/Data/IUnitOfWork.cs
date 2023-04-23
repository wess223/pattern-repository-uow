using PatternRepositoryUoW.API.Data.Repositories;

namespace PatternRepositoryUoW.API.Data
{
    public interface IUnitOfWork : IDisposable
    {
        bool Commit();
        IDepartmentRepository DepartmentRepository { get; }
    }
}
