using Microsoft.EntityFrameworkCore;
using RestaurantAPI.Domain.Entities;

namespace RestaurantAPI.Application.Common.Interface;
public interface IRestaurantDbContext
{
    Task<int> SaveChangesAsync(CancellationToken cancellationToken);
    DbSet<Dish> Dishes { get; set; }
    DbSet<Restaurant> Restaurants { get; set; }
    DbSet<User> Users { get; set; }
}