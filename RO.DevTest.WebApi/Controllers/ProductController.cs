using MediatR;
using Microsoft.AspNetCore.Mvc;
using RO.DevTest.Application.Features.Products.Commands;
using RO.DevTest.Domain.Entities;

namespace RO.DevTest.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IMediator _mediator;

        public ProductController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<ActionResult<Product>> Create([FromBody] CreateProductCommand command)
        {
            var result = await _mediator.Send(command);
            return Ok(result);
        }
    }
}
