using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TableUp.Application.Commands.MenuItems.Create;
using TableUp.Application.Commands.MenuItems.Delete;
using TableUp.Application.Commands.MenuItems.Update;
using TableUp.Application.Queries.MenuItems.GetAll;
using TableUp.Application.Queries.MenuItems.GetAllActive;
using TableUp.Application.Queries.MenuItems.GetByGuid;

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
            return CreatedAtAction(
                    nameof(GetById),            // Nome do método que recupera o recurso
                    new { id = result },        // Rota com o id do recurso criado
                    result                      // Corpo da resposta (pode ser o próprio objeto ou apenas o id)
                );
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            var query = new GetMenuItemByGuidQuery(id);
            var menuItem = await _mediator.Send(query);
            return Ok(menuItem);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            var command = new DeleteMenuItemCommand(id);
            var deleted = await _mediator.Send(command);
            return Ok(deleted) ;
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(Guid id, [FromBody] UpdateMenuItemCommand command)
        {
            command.Guid = id;
            var updated = await _mediator.Send(command);
            return Ok(updated);
        }
    }
}
