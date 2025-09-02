using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TableUp.Application.Commands.MenuItems.Create;
using TableUp.Application.Queries.MenuItems.GetAll;
using TableUp.Application.Queries.MenuItems.GetAllActive;

namespace TableUp.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MenuItemController : ControllerBase
    {
        private readonly IMediator _mediator;

        public MenuItemController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var query = new GetAllMenuItemsQuery();
            var menuItems = await _mediator.Send(query);
            return Ok(menuItems);
        }

        [HttpGet("active")]
        public async Task<IActionResult> GetAllActive()
        {
            var query = new GetAllMenuItemActiveQuery();
            var menuItems = await _mediator.Send(query);
            return Ok(menuItems);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateMenuItemCommand command)
        {
            var result = await _mediator.Send(command);
            // return CreatedAtAction(nameof(GetById), new { id = result.Guid }, result);
            return Ok(result);
        }
    }
}
