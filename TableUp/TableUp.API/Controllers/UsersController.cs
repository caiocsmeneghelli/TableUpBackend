using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using TableUp.Application.Commands.Users.Create;
using TableUp.Application.Commands.Users.Login;
using TableUp.Application.Common;

namespace TableUp.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IMediator _mediator;

        public UsersController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<IActionResult> CreateUser(CreateUserCommand command)
        {
            var result = await _mediator.Send(command);
            return Ok(result);
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login(LoginCommand command)
        {
            // Implement login logic here
            Result result = await _mediator.Send(command);
            return Ok(result);
        }
    }
}