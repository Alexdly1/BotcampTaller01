using Jazani.Application.Admins.Services.Implementations;
using Jazani.Application.Admins.Services;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;
using Jazani.Application.Lias.Services.Implementations;
using Jazani.Application.Lias.Services;

namespace Jazani.Application.Cores.Contexts
{
    public static class ApplicationServicesRegistration
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services)
        {
            services.AddAutoMapper(Assembly.GetExecutingAssembly());

            services.AddTransient<IProcessService, ProcessService>();
            services.AddTransient<IActivityService, ActivityService>();

            return services;
        }
    }
}
