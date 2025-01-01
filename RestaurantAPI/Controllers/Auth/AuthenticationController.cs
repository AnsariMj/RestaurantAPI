using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RestaurantAPI.Application.Handlers.Authentication.Login.Commad;
using RestaurantAPI.Application.Handlers.Authentication.Register.Commands;

namespace RestaurantAPI.Controllers.Auth
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthenticationController : ApiController
    {
        [AllowAnonymous]
        [HttpPost("register")]
        public async Task<IActionResult> RegisterUser([FromBody] RegisterCommand command, CancellationToken cancellationToken)
        {
            var userId = await Mediator.Send(command, cancellationToken);
            return Ok(userId);
        }


        [AllowAnonymous]
        [HttpPost("login")]
        public async Task<IActionResult> Login(LoginCommand query)
        {
            var userToken = await Mediator.Send(query);
            return Ok(userToken);
        }
    }
}
