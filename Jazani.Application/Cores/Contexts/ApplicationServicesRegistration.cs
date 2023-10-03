using Jazani.Application.Admins.Services.Implementations;
using Jazani.Application.Admins.Services;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace Jazani.Application.Cores.Contexts
{
    public static class ApplicationServicesRegistration
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services)
        {
            services.AddAutoMapper(Assembly.GetExecutingAssembly());

            services.AddTransient<IProcessService, ProcessService>();

            return services;
        }
    }
}
