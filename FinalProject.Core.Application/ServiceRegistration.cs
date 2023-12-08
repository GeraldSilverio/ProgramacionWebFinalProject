using FinalProject.Core.Application.Interfaces.Services;
using FinalProject.Core.Application.Services;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace FinalProject.Core.Application
{
    public static class ServiceRegistration
    {
        public static void AddApplicationLayer(this IServiceCollection services)
        {
            services.AddAutoMapper(Assembly.GetExecutingAssembly());
            services.AddTransient<IUserService, UserService>();
            services.AddTransient<ITypeOfCaseServices, TypeOfCaseServices>();
            services.AddTransient<IStatusOfCaseServices, StatusOfCaseService>();
            services.AddTransient(typeof(IGenericService<,,>), typeof(GenericService<,,>));

        }
    }
}