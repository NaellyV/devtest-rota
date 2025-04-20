using MediatR;
using Microsoft.AspNetCore.Mvc;
using RO.DevTest.Application.Features.Sales.Commands;
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
    }
}
