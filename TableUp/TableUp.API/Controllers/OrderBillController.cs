using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TableUp.Application.Commands.OrderBills.Create;
using TableUp.Application.Queries.OrderBills.GetByGuid;
using TableUp.Application.Queries.OrderBills.GetToday;
using TableUp.Application.ViewModels.OrderBills;

namespace TableUp.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class OrderBillController : ControllerBase
    {
        private readonly IMediator _mediator;

        public OrderBillController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("today")]
        public async Task<IActionResult> GetTodayOrderBills()
        {
            var query = new GetOrderBillByDateQuery() { DateTime = DateTime.UtcNow };
            var result = await _mediator.Send(query);
            return Ok(result);
        }

        [HttpGet("{guid}")]
        public async Task<IActionResult> GetByGuid(Guid guid)
        {
            GetOrderBillByGuidQuery query = new GetOrderBillByGuidQuery(guid);
            OrderBillsViewModel? orderBillsViewModel = await _mediator.Send(query);
            if (orderBillsViewModel is null) { return NotFound(); }
            return Ok(orderBillsViewModel);
        }

        [HttpPost]
        public async Task<IActionResult> CreateOrderBill(CreateOrderBillCommand command)
        {
            var result = await _mediator.Send(command);
            return Ok(result);
        }

        [HttpPut("{guid}/close")]
        public async Task<IActionResult> CloseOrderBill(Guid guid)
        {
            // Implementation to close an OrderBill
            return Ok();
        }

        [HttpPut("{guid}/cancel")]
        public async Task<IActionResult> CancelOrderBill(Guid guid)
        {
            // Implementation to cancel an OrderBill
            return Ok();
        }

        [HttpPut("{guid}/add-item")]
        public async Task<IActionResult> AddItemToOrderBill(Guid guid)
        {
            // Implementation to add an item to an OrderBill
            return Ok();
        }
    }
}