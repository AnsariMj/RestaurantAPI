using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using RestaurantAPI.Application.Common.Interface;
using RestaurantAPI.Application.Handlers.Authentication.Register.Common;
using RestaurantAPI.Domain.Entities;

namespace RestaurantAPI.Application.Handlers.Authentication.Register.Commands;

public class RegisterCommandHandler : IRequestHandler<RegisterCommand, RegisterResponse>
{
    private readonly IRestaurantDbContext _dbContext;
    private readonly IPasswordHasher<User> _passwordHasher;

    public RegisterCommandHandler(IRestaurantDbContext dbContext, IPasswordHasher<User> passwordHasher)
    {
        _dbContext = dbContext;
        _passwordHasher = passwordHasher;
    }

    public async Task<RegisterResponse> Handle(RegisterCommand command, CancellationToken cancellationToken)
    {
        var existingUser = await _dbContext.Users
           .FirstOrDefaultAsync(u => u.Email == command.Email, cancellationToken);
        var user = new User
        {
            FirstName = command.FirstName,
            LastName = command.LastName,
            Email = command.Email,
            PasswordHash = command.Password,
        };

        user.PasswordHash = _passwordHasher.HashPassword(user, command.Password);

        _dbContext.Users.Add(user);
        var res = await _dbContext.SaveChangesAsync(cancellationToken);
        return new RegisterResponse
        {
            Success = true,
            Message = "User registered successfully.",
            UserId = user.Id
        };
    }
}
