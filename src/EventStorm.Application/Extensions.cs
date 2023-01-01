using EventStorm.Application.Services;
using EventStorm.Application.Sieve;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Sieve.Models;
using Sieve.Services;
using System.Reflection;

namespace EventStorm.Application.Extensions
{
    public static class Extensions
    {
        public static IServiceCollection AddApplication(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddAutoMapper(Assembly.GetExecutingAssembly());

			services.Configure<SieveOptions>(configuration.GetSection("Sieve"));
			services.AddScoped<ISieveProcessor, ApplicationSieveProcessor>();

            services.AddScoped<IAttenderService, AttenderService>();
            services.AddScoped<IMeetingService, MeetingService>();

			return services;
        }
    }
}