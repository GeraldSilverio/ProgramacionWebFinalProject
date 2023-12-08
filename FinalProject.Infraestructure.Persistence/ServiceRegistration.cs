using FinalProject.Core.Application.Interfaces.Repositories;
using FinalProject.Infraestructure.Persistence.Context;
using FinalProject.Infraestructure.Persistence.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace FinalProject.Infraestructure.Persistence
{
    public static class ServiceRegistration
    {
        public static void AddInfraestructurePersistence(this IServiceCollection services, IConfiguration configuration)
        {
            #region DbContext
            if (configuration.GetValue<bool>("UseInMemoryDataBase"))
            {
                services.AddDbContext<ApplicationContext>(options =>
                options.UseInMemoryDatabase("ApplicationDb")
                );
            }
            else
            {
                services.AddDbContext<ApplicationContext>(options =>
                options.UseSqlServer(configuration.GetConnectionString("DefaultConnection"),
                m => m.MigrationsAssembly(typeof(ApplicationContext).Assembly.FullName)));
            }

            #endregion
            services.AddTransient(typeof(IGenericRepository<>), typeof(GenericRepository<>));
            services.AddTransient<ITypeOfCaseRepository, TypeOfCaseRepository>();
            services.AddTransient<IStatusOfCaseRepository, StatusOfCaseRepository>();
            services.AddTransient<ICaseRepository, CaseRepository>();
        }
    }
}