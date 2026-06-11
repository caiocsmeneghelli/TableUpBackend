using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TableUp.Application.Queries.OrderItems.GetAll;
using TableUp.Application.Queries.OrderItems.GetByGuid;

namespace TableUp.API.Controllers
{
    [Route("api/order-items")]
    [ApiController]
    public class OrderItemController : ControllerBase
    {
        private readonly IMediator _mediator;

        public OrderItemController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("{guid}")]
        [Authorize]
        public async Task<IActionResult> GetByGuid(Guid guid)
        {
            GetOrderItemByGuidQuery query = new GetOrderItemByGuidQuery() { OrderItemGuid = guid };
            var result = await _mediator.Send(query);
            if (result == null) { return NotFound(); }
            return Ok(result);
        }

        [HttpGet("pending")]
        [Authorize]
        public async Task<IActionResult> GetAllPendingOrderItems()
        {
            GetAllOrderItemsQuery query = new GetAllOrderItemsQuery(true);
            var result = await _mediator.Send(query);
            return Ok(result);
        }

        [HttpGet]
        [Authorize]
        public async Task<IActionResult> GetAll()
        {
            GetAllOrderItemsQuery query = new GetAllOrderItemsQuery(false);
            var result = await _mediator.Send(query);
            return Ok(result);
        }

        [HttpPut]
        [Authorize]
        public async Task<IActionResult> Complete()
        {
            // implement the logic to complete order item
            return Ok();
        }
    }
}
