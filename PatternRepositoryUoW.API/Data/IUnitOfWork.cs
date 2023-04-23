namespace PatternRepositoryUoW.API.Data
{
    public interface IUnitOfWork : IDisposable
    {
        bool Commit();
    }
}
