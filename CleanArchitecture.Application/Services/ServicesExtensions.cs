using CleanArchitecture.Application.Shared.Behavior;
using FluentValidation;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace CleanArchitecture.Application.Services
{
    public static class ServiceExtensions
    {
        public static void ConfigureApplicationApp(this IServiceCollection services, Assembly applicationAssembly)
        {
            services.AddAutoMapper(applicationAssembly);
            services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(applicationAssembly));
            services.AddValidatorsFromAssembly(applicationAssembly);
            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(ValidationBehavior<,>));
        }
    }
}