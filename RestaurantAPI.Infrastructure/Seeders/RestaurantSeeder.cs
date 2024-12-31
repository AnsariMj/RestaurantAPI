using RestaurantAPI.Domain.Entities;
using RestaurantAPI.Infrastructure.Persistence;

namespace RestaurantAPI.Infrastructure.Seeders;

internal class RestaurantSeeder(RestaurantDbContext dbContext) : IRestaurantSeeder
{
    public async Task Seed()
    {
        if (await dbContext.Database.CanConnectAsync())
        {
            if (!dbContext.Restaurants  .Any())
            {
                var restaurants = GetRestaurants();
                dbContext.Restaurants.AddRange(restaurants);
                await dbContext.SaveChangesAsync();
            }
        }
    }

    private IEnumerable<Restaurant> GetRestaurants()
    {
        List<Restaurant> restaurants = [
    new()
    {
        Name = "KFC",
        Category = "Fast Food",
        Description = "KFC (short for Kentucky Fried Chicken) is an American fast food restaurant chain.",
        ContactEmail = "contact@kfc.com",
        HasDelivery = true,
        Dishes = [
            new()
            {
                Name = "Nashville Hot Chicken",
                Description = "Nashville Hot Chicken (10 pcs.)",
                Price = 10.30M
            },
            new()
            {
                Name = "Chicken Nuggets",
                Description = "Chicken Nuggets (5 pcs.)",
                Price = 5.30M
            }
        ],
        Address = new()
        {
            City = "London",
            Street = "Cork St 5",
            PostalCode = "WC2N 5DU"
        }
    },
    new ()
    {
        Name = "Pizza Hut",
        Category = "Italian",
        Description = "Pizza Hut is an American multinational restaurant chain specializing in Italian-American cuisine.",
        ContactEmail = "contact@pizzahut.com",
        HasDelivery = true,
        Dishes = [
            new()
            {
                Name = "Pepperoni Pizza",
                Description = "Classic pepperoni pizza with mozzarella cheese.",
                Price = 12.50M
            },
            new()
            {
                Name = "Veggie Pizza",
                Description = "Loaded with fresh vegetables and cheese.",
                Price = 10.00M
            }
        ],
        Address = new()
        {
            City = "New York",
            Street = "5th Ave 10",
            PostalCode = "NY10001"
        }
    },
    new ()
    {
        Name = "Burger King",
        Category = "Fast Food",
        Description = "Burger King is an American-based multinational chain of hamburger fast food restaurants.",
        ContactEmail = "contact@burgerking.com",
        HasDelivery = true,
        Dishes = [
            new()
            {
                Name = "Whopper",
                Description = "Signature flame-grilled beef burger.",
                Price = 8.99M
            },
            new()
            {
                Name = "Chicken Fries",
                Description = "Breaded chicken strips shaped like fries.",
                Price = 4.99M
            }
        ],
        Address = new()
        {
            City = "Los Angeles",
            Street = "Sunset Blvd 25",
            PostalCode = "CA90028"
        }
    },
    new ()
    {
        Name = "Starbucks",
        Category = "Cafe",
        Description = "Starbucks is an American multinational chain of coffeehouses and roastery reserves.",
        ContactEmail = "contact@starbucks.com",
        HasDelivery = false,
        Dishes = [
            new()
            {
                Name = "Caramel Macchiato",
                Description = "Espresso with steamed milk and caramel drizzle.",
                Price = 5.45M
            },
            new()
            {
                Name = "Blueberry Muffin",
                Description = "Freshly baked muffin with blueberries.",
                Price = 3.50M
            }
        ],
        Address = new()
        {
            City = "Seattle",
            Street = "Pike St 1912",
            PostalCode = "WA98101"
        }
    }
   ];
        return restaurants;

    }
}
