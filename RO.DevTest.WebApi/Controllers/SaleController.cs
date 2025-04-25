using MediatR;
using Microsoft.AspNetCore.Mvc;
using RO.DevTest.Application.Features.Sales.Commands;
using RO.DevTest.Application.Features.Sales.Commands.UpdateSale;
using RO.DevTest.Application.Features.Sales.Commands.DeleteSale;
using RO.DevTest.Domain.Entities;

namespace RO.DevTest.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SaleController : ControllerBase
    {
        private readonly IMediator _mediator;

        public SaleController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
public async Task<ActionResult<Sale>> Create([FromBody] CreateSaleCommand command)
{
    var result = await _mediator.Send(command);
    return Ok(result);
}

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(Guid id, [FromBody] UpdateSaleCommand command)
        {
            if (id != command.Id)
                return BadRequest("Id mismatch");

            await _mediator.Send(command);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            await _mediator.Send(new DeleteSaleCommand { Id = id });
            return NoContent();
        }
    }
}
