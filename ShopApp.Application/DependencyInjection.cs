
using System.Reflection;
// using ShopApp.Application.Authentication.Commands;
// using ShopApp.Application.Authentication.Commands.Register;
// using ShopApp.Application.Authentication.Common;
// using ShopApp.Application.Authentication.Queries.Login;
using ShopApp.Application.Common.Behaviors;
// using ErrorOr;
using FluentValidation;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;

namespace ShopApp.Application.Services;


public static class DependencyInjection
{
    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
        
        
        // var assemblies = new[]
        // {
        //     typeof(RegisterCommandValidtor).Assembly,
        //     typeof(LoginQueryValidation).Assembly
        // };

        // services.AddValidatorsFromAssemblies(assemblies, ServiceLifetime.Scoped);
        services.AddScoped(typeof(IPipelineBehavior<,>), typeof(ValidationBehavior<,>));
        services.AddMediatR(typeof(DependencyInjection).Assembly);
        return services;
    }
}

