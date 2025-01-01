using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using RestaurantAPI.Domain.Entities;
using RestaurantAPI.Infrastructure.Persistence;
using RestaurantAPI.Infrastructure.Repositories;
using RestaurantAPI.Infrastructure.Seeders;
using Microsoft.Extensions.Options;
using RestaurantAPI.Application.Common.Interface.Authentication;
using RestaurantAPI.Infrastructure.Authentication;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using RestaurantAPI.Application.Common.Interface;
using RestaurantAPI.Application.Services;
using RestaurantAPI.Infrastructure.Services;



namespace RestaurantAPI.Infrastructure.Extensions;

public static class ServiceExtensions
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
    {
        // Register JWT Authentication
        services.AddAuth(configuration);

        // Register DbContext and its Interface
        var connectionString = configuration.GetConnectionString("RestaurantConnectionUrl");
        services.AddDbContext<RestaurantDbContext>(options => options.UseSqlServer(connectionString));
        services.AddScoped<IRestaurantDbContext, RestaurantDbContext>();

        // Register Identity
        services.AddIdentityApiEndpoints<User>().AddEntityFrameworkStores<RestaurantDbContext>();

        // Register Seeder
        services.AddScoped<IRestaurantSeeder, RestaurantSeeder>();

        // Register Seeder
        services.AddScoped<IRestaurantSeeder, RestaurantSeeder>();

        // Register DateTimeProvider
        services.AddSingleton<IDateTimeProvider, DateTimeProvider>();
        //services.AddSingleton(Options.Create(Jwt)
        //services.AddScoped<IRestaurantsRepository, RestaurantsRepository>();
        //services.AddScoped<IDishRepository, DishRepository>();
        return services;
    }


    public static IServiceCollection AddAuth(this IServiceCollection services, IConfiguration configuration)
    {
        var jwtSettings = new JwtSettings();
        configuration.Bind(JwtSettings.SectionName, jwtSettings);
        services.Configure<JwtSettings>(configuration.GetSection(JwtSettings.SectionName));
        var tokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuer = true,
            ValidateAudience = true,
            ValidateLifetime = true,
            ValidateIssuerSigningKey = true,
            ValidIssuer = jwtSettings.Issuer,
            ValidAudience = jwtSettings.Audience,
            IssuerSigningKey = new SymmetricSecurityKey(
                Encoding.UTF8.GetBytes(jwtSettings.Secret))
        };

        services.AddSingleton(Options.Create(jwtSettings));
        services.AddSingleton<IJwtTokenGenerator, JwtTokenGenerator>();
        services.AddAuthentication(defaultScheme: JwtBearerDefaults.AuthenticationScheme).AddJwtBearer(option => option.TokenValidationParameters = tokenValidationParameters);
        return services;

    }
}
