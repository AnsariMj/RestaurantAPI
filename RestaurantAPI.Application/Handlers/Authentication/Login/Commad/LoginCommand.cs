using MediatR;
using RestaurantAPI.Application.Handlers.Authentication.Login.Common;

namespace RestaurantAPI.Application.Handlers.Authentication.Login.Commad;

public class LoginCommand : IRequest<LoginResponse>
{
    public string Email { get; set; }
    public string Password { get; set; }
}
