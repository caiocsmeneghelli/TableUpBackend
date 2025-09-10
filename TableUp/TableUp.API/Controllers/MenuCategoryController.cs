using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TableUp.Application.Commands.MenuCategories.Create;
using TableUp.Application.Commands.MenuCategories.Delete;
using TableUp.Application.Common;
using TableUp.Application.Queries.MenuCategories.GetAll;
using TableUp.Application.Queries.MenuCategories.GetByGuid;
using TableUp.Application.ViewModels.MenuCategories;

namespace TableUp.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MenuCategoryController : ControllerBase
    {
        private readonly IMediator _mediator;

        public MenuCategoryController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("")]
        public async Task<IActionResult> GetAll()
        {
            var query = new GetAllMenuCategoriesQuery();
            var categories = await _mediator.Send(query);
            return Ok(categories);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetByGuid(Guid id)
        {
            GetMenuCategoryByGuidQuery query = new GetMenuCategoryByGuidQuery(id);
            MenuCategoryViewModel? vm = await _mediator.Send(query);
            if (vm == null)
                return NotFound();

            return Ok(vm);
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateMenuCategoryCommand command)
        {
            Result result = await _mediator.Send(command);
            if (result.IsFailure) { return BadRequest(result); }

            return CreatedAtAction(nameof(GetByGuid), new { id = result.Value }, null);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            DeleteMenuCategoryCommand command = new DeleteMenuCategoryCommand(id);
            Result result = await _mediator.Send(command);

            if (result.IsFailure) { return NotFound(result); }

            return NoContent();
        }
    }
}
