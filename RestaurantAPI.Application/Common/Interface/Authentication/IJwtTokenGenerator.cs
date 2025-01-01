using RestaurantAPI.Domain.Entities;

namespace RestaurantAPI.Application.Common.Interface.Authentication;

public interface IJwtTokenGenerator
{
    string GenerateToken(User user);
}
