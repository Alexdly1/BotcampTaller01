using Jazani.Domain.Admins.Repositories;
using Jazani.Domain.Lias.Repositories;
using Jazani.Infrastructure.Admins.Persistences;
using Jazani.Infrastructure.Lias.Persistences;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Jazani.Infrastructure.Cores.Contexts
{
    public static class InfrastructureServiceRegistration
    {
        public static IServiceCollection AddInfrastructureServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<ApplicationDbContext>(options =>
            {
                options.UseSqlServer(configuration.GetConnectionString("DbConnection"));
            });

            services.AddTransient<IProcessRepository, ProcessRepository>();
            services.AddTransient<IActivityRepository, ActivityRepository>();

            return services;
        }
    }
}
