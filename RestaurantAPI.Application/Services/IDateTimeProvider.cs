namespace RestaurantAPI.Application.Services;
public interface IDateTimeProvider
{
    DateTime UtcNow { get; }
}
