using ShopApp.Api.Common.Mapping;

namespace ShopApp.Api;


public static class DependencyInjection
{
    public static IServiceCollection AddPresentaion(this IServiceCollection services)
    {
        services.AddMapping();
        services.AddControllers();
        
        return services;
    }
}
