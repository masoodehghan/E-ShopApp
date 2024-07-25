using System.Text;
using BubberDinner.Infrastructure.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using ShopApp.Application.Common.Interfaces.Authentication;
using ShopApp.Application.Common.Interfaces.Persistence;
using ShopApp.Application.Common.Interfaces.Services;
using ShopApp.Domain.UserAggregate;
using ShopApp.Infrastructure.Authentication;
using ShopApp.Infrastructure.Persistence.Interceptors;
using ShopApp.Infrustructure.Authentication;
using ShopApp.Infrustructure.Persistence;
using ShopApp.Infrustructure.Persistence.Repositories;

namespace ShopApp.Infrustructure;


public static class DependencyInjection
{
    public static IServiceCollection AddInfrustructure(
        this IServiceCollection services,
        IConfiguration configuration)
    {
        AddPersistence(services, configuration);
        AddAuth(services, configuration);
        services.AddSingleton<IDateTimeProvider, DateTimeProvider>();
        return services;
    }

    public static IServiceCollection AddPersistence(
        this IServiceCollection services,
        IConfiguration configuration
    )
    {
        services.AddScoped<IUserRepository, UserRepository>();
        services.AddScoped<ICategoryRepository, CategoryRepository>();
        services.AddScoped<IProductRepository, ProductRepository>();
        services.AddScoped<PublishDomainEventsInterceptor>();
        services.AddScoped<IDapperContext, DapperContext>(s => new DapperContext(configuration));

        services.AddDbContext<ShopAppDbContext>(
            options => options.UseSqlite(configuration.GetConnectionString("DefaultConnection"))
        );

        return services;
    }


    public static IServiceCollection AddAuth(
        this IServiceCollection services,
        IConfiguration configuration
    )
    {
        var superUserSecret = new SuperUserSecret();
        configuration.Bind(SuperUserSecret.SectionName, superUserSecret);
        services.AddSingleton(superUserSecret);

        var jwtSettings = new JwtSettings();
        configuration.Bind(JwtSettings.SectionName, jwtSettings);
        services.AddSingleton(Options.Create(jwtSettings));
        services.AddSingleton<IJwtTokenGenerator, JwtTokenGenerator>();

        services.AddIdentity<IdentityUser, IdentityRole>()
                    .AddEntityFrameworkStores<ShopAppDbContext>();

        services.AddAuthentication(options => 
        {
            options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
            options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
        })
            .AddJwtBearer(options => options.TokenValidationParameters = new TokenValidationParameters()
            {
                ValidateIssuer = true,
                ValidateAudience = true,
                ValidateLifetime = true,
                ValidateIssuerSigningKey = true,
                ValidIssuer = jwtSettings.Issuer,
                ValidAudience = jwtSettings.Audience,
                IssuerSigningKey = new SymmetricSecurityKey(
                    Encoding.UTF8.GetBytes(jwtSettings.Secrets!)
                )
            });

        return services;
    }

}

