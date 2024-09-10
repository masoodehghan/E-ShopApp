using ShopApp.Application.Common.Behaviors;
using FluentValidation;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using ShopApp.Application.Authentication.Commands.Register;
using System.Reflection;
using ShopApp.Application.Products.Commands;

namespace ShopApp.Application.Services;


public static class DependencyInjection
{
    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
        
        
        var assemblies = new[]
        {
            typeof(RegisterCommandValidator).Assembly,
            typeof(ProductValidator).Assembly
            // typeof(LoginQueryValidation).Assembly
        };

        services.AddValidatorsFromAssemblies(assemblies, ServiceLifetime.Scoped);
        services.AddScoped(typeof(IPipelineBehavior<,>), typeof(ValidationBehavior<,>));
        services.AddMediatR(cfg => {
            cfg.RegisterServicesFromAssemblies(Assembly.GetExecutingAssembly());
        });

        return services;
    }
}

