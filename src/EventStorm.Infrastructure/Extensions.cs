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

            services.AddDbContext<EventStormDbContext>(options =>
             options.UseNpgsql(configuration.GetConnectionString("Default")));

            return services;
        }
    }
}