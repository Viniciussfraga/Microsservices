using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsservices.Application.Commands;
using Microsservices.Application.Queries;

namespace Microsservices.API.Controllers
{
    [Route("api/orders")]
    [ApiController]
    public class OrdersController : ControllerBase
    {
        private readonly IMediator _mediator;
        public OrdersController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(Guid id)
        {
            var query = new GetOrderById(id);

            var result = await _mediator.Send(query);

            if(result is null)
                return NotFound();

            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] AddOrder command)
        {
            var id = await _mediator.Send(command);

            return CreatedAtAction(nameof(Get), new { id = id }, command);
        }
    }
}
