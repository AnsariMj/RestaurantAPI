using Microsoft.OpenApi.Models;

namespace RestaurantAPI.Extensions;

public static class ServiceExtensions
{
    public static IServiceCollection AddPresentation(this IServiceCollection services)
    {
        services.AddControllers();
        services.AddEndpointsApiExplorer();
        services.AddSwaggerGen(c =>
        {
            c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
            {
                Name = "Authorization",
                Description = "Please enter a valid token",
                Type = SecuritySchemeType.Http,
                Scheme = "Bearer"
            });
        });
        return services;
    }
}