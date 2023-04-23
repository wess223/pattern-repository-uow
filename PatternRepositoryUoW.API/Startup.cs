using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using PatternRepositoryUoW.API.Data;

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

            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "Pattern.Repository and UoW", Version = "v1" });
            });
            
            services.AddDbContext<ApplicationContext>(optionsBuilder =>
                optionsBuilder
                    .UseSqlServer("Data Source=(localdb)\\mssqllocaldb;Initial Catalog=RepositoryAndUoW; Integrated Security=True;")
                    .LogTo(Console.WriteLine)
                    .EnableSensitiveDataLogging());
          
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "Pattern.Repository and UoW v1"));
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
