using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using ShopApp.Infrustructure.Persistence;

namespace ShopApp.Infrustructure;


public static class DependencyInjection
{
    public static IServiceCollection AddInfrustructure(
        this IServiceCollection services,
        IConfiguration configuration)
    {
        Console.WriteLine("sadfa" + configuration.GetConnectionString("DefaultConnection"));
        services.AddDbContext<ShopAppDbContext>(
            options => options.UseSqlite(configuration.GetConnectionString("DefaultConnection"))
        );

        return services;
    }
}

