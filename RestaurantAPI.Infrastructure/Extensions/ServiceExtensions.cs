using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using RestaurantAPI.Domain.Entities;
using RestaurantAPI.Infrastructure.Persistence;
using RestaurantAPI.Infrastructure.Repositories;
using RestaurantAPI.Infrastructure.Seeders;

namespace RestaurantAPI.Infrastructure.Extensions;

public static class ServiceExtensions
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
    {
        //services.AddDbContext<ApplicationDbContext>(options =>
        //    options.UseSqlServer(configuration.GetConnectionString("DefaultConnection")));
        var connectionString = configuration.GetConnectionString("RestaurantConnectionUrl");
        services.AddDbContext<RestaurantDbContext>(options => options.UseSqlServer(connectionString));
        services.AddIdentityApiEndpoints<User>()
            .AddEntityFrameworkStores<RestaurantDbContext>();

        services.AddScoped<IRestaurantSeeder, RestaurantSeeder>();
        //services.AddScoped<IRestaurantsRepository, RestaurantsRepository>();
        //services.AddScoped<IDishRepository, DishRepository>();
        return services;
    }
}
