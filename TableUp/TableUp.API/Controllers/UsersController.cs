using MediatR;
using Microsoft.AspNetCore.Mvc;

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

        [HttpGet()]
        public async Task<IActionResult> Get()
        {
            return Ok("UsersController is working!");
        }
        
    }
}