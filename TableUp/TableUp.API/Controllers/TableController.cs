using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TableUp.Application.Commands.Tables.Create;
using TableUp.Application.Common;
using TableUp.Application.Queries.Tables.GetAll;
using TableUp.Application.ViewModels.Tables;

namespace TableUp.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
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
    }
}
