using PatternRepositoryUoW.API.Data.Repositories;

namespace PatternRepositoryUoW.API.Data
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationContext _context;

        public UnitOfWork(ApplicationContext context)
        {
            _context = context;
        }

        //config aplicada para não instânciar todos os repositorios na criação da instância do UoW.
        //config ajuda para instanciar o repositorio somente quando o mesmo for chamado.
        //Ajuda a não ter vários objetos na memória sem utilizar os mesmos.
        //Porém Devo aplicar essa cofig para todos os respositórios.
        private IDepartmentRepository _departmentRepository;
        public IDepartmentRepository DepartmentRepository
        {
            get => _departmentRepository ?? (_departmentRepository = new DepartmentRepository(_context));
        }

        public bool Commit()
        {
            return _context.SaveChanges() > 0;
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
