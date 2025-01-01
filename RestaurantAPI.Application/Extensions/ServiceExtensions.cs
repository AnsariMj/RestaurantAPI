using System.Reflection;
using Microsoft.Extensions.DependencyInjection;

namespace RestaurantAPI.Application.Extensions;

public static class ServiceExtensions
{
    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
        //services.AddMediatR(typeof(ServiceExtensions).Assembly);
        services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly()));
    
        return services;
    }
}
