using MediatR;
using Microsoft.AspNetCore.Mvc;
using TableUp.Application.Commands.OrderBills.Create;

namespace TableUp.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderBillController : ControllerBase
    {
        private readonly IMediator _mediator;

        public OrderBillController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("{guid}")]
        public async Task<IActionResult> GetByGuid(Guid guid)
        {
            // Implementation to get OrderBill by guid
            return Ok();
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