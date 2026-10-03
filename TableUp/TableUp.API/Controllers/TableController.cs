using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TableUp.Application.Commands.Tables.Create;
using TableUp.Application.Commands.Tables.Inactive;
using TableUp.Application.Commands.Tables.Update;
using TableUp.Application.Common;
using TableUp.Application.Queries.Tables.GetAll;
using TableUp.Application.ViewModels.Tables;

namespace TableUp.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class TableController : ControllerBase
    {
        private readonly IMediator _mediatr;

        public TableController(IMediator mediatr)
        {
            _mediatr = mediatr;
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateTableCommand command)
        {
            Result result = await _mediatr.Send(command);
            if (result.IsFailure) { return BadRequest(result); }

            return Ok(result);
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            GetAllTablesQuery query = new GetAllTablesQuery();
            List<TableViewModel> vwModel = await _mediatr.Send(query);
            return Ok(vwModel);
        }

        [HttpPut("{guid}")]
        public async Task<IActionResult> Update(Guid guid, [FromBody] UpdateTableCommand command)
        {
            command.Guid = guid;
            Result result = await _mediatr.Send(command);
            if (result.IsFailure) { return BadRequest(result); }
            return Ok(result);
        }

        [HttpDelete("{guid}")]
        public async Task<IActionResult> Inactive(Guid guid)
        {
            var command = new InactiveTableCommand { Guid = guid };
            Result result = await _mediatr.Send(command);
            if (result.IsFailure) { return NotFound(result); }
            return NoContent();
        }
    }
}
