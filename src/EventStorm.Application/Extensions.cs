using EventStorm.Application.Requests;
using EventStorm.Application.Requests.Validators;
using EventStorm.Application.Services;
using EventStorm.Application.Sieve;
using FluentValidation;
using FluentValidation.AspNetCore;
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
            services.AddFluentValidation();

            services.AddAutoMapper(Assembly.GetExecutingAssembly());

			services.Configure<SieveOptions>(configuration.GetSection("Sieve"));
			services.AddScoped<ISieveProcessor, ApplicationSieveProcessor>();

            services.AddScoped<IValidator<CreateMeetingDto>, CreateMeetingDtoValidator>();

            services.AddScoped<IAttenderService, AttenderService>();
            services.AddScoped<IMeetingService, MeetingService>();

			return services;
        }
    }
}