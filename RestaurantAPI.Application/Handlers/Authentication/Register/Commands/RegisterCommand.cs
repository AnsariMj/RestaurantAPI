using MediatR;
using RestaurantAPI.Application.Handlers.Authentication.Register.Common;

namespace RestaurantAPI.Application.Handlers.Authentication.Register.Commands;

public class RegisterCommand : IRequest<RegisterResponse>
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Email { get; set; }
    public string Password { get; set; }
}
