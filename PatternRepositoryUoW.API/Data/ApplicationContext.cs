using Microsoft.EntityFrameworkCore;
using PatternRepositoryUoW.API.Domain;

namespace PatternRepositoryUoW.API.Data
{
    public class ApplicationContext : DbContext
    {
        public DbSet<Department> Departments{ get; set; }
        public DbSet<Collaborator> Collaborators{ get; set; }

        public ApplicationContext(DbContextOptions<ApplicationContext> options) : base (options)
        {

        }
    }
}
