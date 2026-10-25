using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TableUp.Application.Commands.OrderItems.ChangeStatus;
using TableUp.Application.Common;
using TableUp.Application.Queries.OrderItems.GetAll;
using TableUp.Application.Queries.OrderItems.GetByGuid;
using TableUp.Domain.Enums;

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

        [HttpPut("{guid}/complete")]
        [Authorize]
        public async Task<IActionResult> Complete(Guid guid)
        {
            ChangeOrderItemStatusCommand command = new ChangeOrderItemStatusCommand(guid, EStatusOrderItem.Completd);
            Result result = await _mediator.Send(command);
            if (result.IsFailure) { return BadRequest(result); }
            return Ok(result);
        }

        [HttpPut("{guid}/cancel")]
        [Authorize]
        public async Task<IActionResult> Cancel(Guid guid)
        {
            ChangeOrderItemStatusCommand command = new ChangeOrderItemStatusCommand(guid, EStatusOrderItem.Canceled);
            Result result = await _mediator.Send(command);
            if (result.IsFailure) { return BadRequest(result); }
            return Ok(result);
        }
    }
}
