using MediatR;
using Microsoft.AspNetCore.Mvc;
using RO.DevTest.Application.Contracts.Persistance.Repositories;
using RO.DevTest.Application.Features.Products.Commands;
using RO.DevTest.Application.Features.Products.Commands.UpdateProduct;
using RO.DevTest.Application.Features.Products.Commands.DeleteProduct;
using RO.DevTest.Domain.Entities;

namespace RO.DevTest.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {   

         private readonly IProductRepository _productRepository;
        private readonly IMediator _mediator;

        public ProductController(IMediator mediator, IProductRepository productRepository)
        {
            _productRepository = productRepository;
            _mediator = mediator;
        }


          [HttpGet]
        public async Task<ActionResult<IEnumerable<Product>>> GetAll()
        {
            var products = await _productRepository.GetAllAsync();
            return Ok(products);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Product>> GetById(Guid id)
        {
            var product = await _productRepository.GetByIdAsync(id);
            if (product == null)
                return NotFound();
            return Ok(product);
        }


        [HttpPost]
        public async Task<ActionResult<Product>> Create([FromBody] CreateProductCommand command)
        {
            var result = await _mediator.Send(command);
            return Ok(result);
        }


        [HttpPut("{id}")]
        public async Task<IActionResult> Update(Guid id, [FromBody] UpdateProductCommand command)
        {
            if (id != command.Id)
                return BadRequest("Id mismatch");

            await _mediator.Send(command);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            await _mediator.Send(new DeleteProductCommand { Id = id });
            return NoContent();
        }
    }
}
