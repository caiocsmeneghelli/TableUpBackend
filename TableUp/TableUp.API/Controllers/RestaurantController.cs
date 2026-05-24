using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TableUp.Application.Common;
using TableUp.Application.Queries.Restaurants.GetAll;

namespace TableUp.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RestaurantController : ControllerBase
    {
        private readonly IMediator _mediator;

        public RestaurantController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("active")]
        public async Task<IActionResult> GetAllActive()
        {
            var query = new GetAllRestaurantQuery(true);
            var restaurants = await _mediator.Send(query);
            return Ok(restaurants);
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var query = new GetAllRestaurantQuery(false);
            var restaurants = await _mediator.Send(query);
            return Ok(restaurants);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            var query = new GetRestaurantByGuidQuery(id);
            var restaurant = await _mediator.Send(query);
            return Ok(restaurant);
        }

        [HttpPost]
        [Authorize]
        public async Task<IActionResult> Create([FromBody] CreateRestaurantCommand command)
        {
            Result result = await _mediator.Send(command);
            if (result.IsFailure) { return BadRequest(result); }
            return CreatedAtAction(
                    nameof(GetById),            // Nome do método que recupera o recurso
                    new { id = result.Value },        // Rota com o id do recurso criado
                    result                      // Corpo da resposta (pode ser o próprio objeto ou apenas o id)
                );
        }
}
