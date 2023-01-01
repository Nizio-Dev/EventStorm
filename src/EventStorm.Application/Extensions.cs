using EventStorm.Application.Services;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace EventStorm.Application.Extensions
{
    public static class Extensions
    {
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
            services.AddAutoMapper(Assembly.GetExecutingAssembly());

            services.AddScoped<IAttenderService, AttenderService>();
            services.AddScoped<IMeetingService, MeetingService>();

			return services;
        }
    }
}