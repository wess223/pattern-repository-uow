using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using PatternRepositoryUoW.API.Data;
using PatternRepositoryUoW.API.Data.Repositories;
using PatternRepositoryUoW.API.Domain;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace PatternRepositoryUoW.API
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {

            services.AddControllers().AddJsonOptions(options =>
            {
                //config para ignorar quando temos informações com referências ciclicas.
                options.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles;
            });

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "Pattern.Repository and UoW", Version = "v1" });
            });

            services.AddDbContext<ApplicationContext>(optionsBuilder =>
                optionsBuilder
                    .UseSqlServer("Data Source=(localdb)\\mssqllocaldb;Initial Catalog=RepositoryAndUoW; Integrated Security=True;")
                    .LogTo(Console.WriteLine)
                    .EnableSensitiveDataLogging());

            services.AddScoped<IDepartmentRepository, DepartmentRepository>();

        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "Pattern.Repository and UoW v1"));
            }

            DatabaseInitialize(app);

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }

        //Criar e popular dados inicial se o banco não existir.
        private void DatabaseInitialize(IApplicationBuilder app)
        {
            using var db = app
                .ApplicationServices
                .CreateScope()
                .ServiceProvider
                .GetRequiredService<ApplicationContext>();

            if (db.Database.EnsureCreated())
            {
                db.Departments.AddRange(Enumerable.Range(1, 10)
                    .Select(p => new Department
                    {
                        Description = $"Departamento - {p}",
                        Collaborators = Enumerable.Range(1, 10)
                        .Select(x => new Collaborator
                        {
                            Name = $"Colaborador {x}/{p}"
                        }).ToList()
                    }));

                db.SaveChanges();
            }
        }
    }
}
