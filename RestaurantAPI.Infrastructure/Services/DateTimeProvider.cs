using RestaurantAPI.Application.Services;

namespace RestaurantAPI.Infrastructure.Services;
public class DateTimeProvider : IDateTimeProvider
{
    public DateTime UtcNow => DateTime.UtcNow;
}
