using EventStorm.Infrastructure.Persistance;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace EventStorm.Infrastructure.Extensions
{
    public static class Extensions
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddScoped<EventStormDbContext>();

            var serverVersion = new MySqlServerVersion(new Version(8, 0, 31));

            services.AddDbContext<EventStormDbContext>(options =>
            {
                options.UseMySql(configuration.GetConnectionString("Default"), serverVersion);
            });

            return services;
        }
    }
}