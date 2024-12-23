using Application.Behaviors;
using Application.Services;
using FluentValidation;
using Microsoft.Extensions.DependencyInjection;
using System.Runtime.CompilerServices;

namespace Application
{
    public static class DependencyInjection
    {

        public static IServiceCollection AddApplication(this IServiceCollection service)
        {
            var assembly = typeof(DependencyInjection).Assembly;
            service.AddMediatR(op =>
            {
                op.RegisterServicesFromAssembly(assembly);
                op.AddOpenBehavior(typeof(LoggingBehavior<,>));
            });
            service.AddValidatorsFromAssembly(assembly);
            service.AddAutoMapper(assembly);
            return service;
        }

    }
}
