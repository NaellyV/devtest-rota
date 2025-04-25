using MediatR;
using RO.DevTest.Application.Contracts.Persistance.Repositories;
using Microsoft.AspNetCore.Mvc;
using RO.DevTest.Application.Features.Sales.Commands;
using RO.DevTest.Application.Features.Sales.Commands.UpdateSale;
using RO.DevTest.Application.Features.Sales.Commands.DeleteSale;
using RO.DevTest.Domain.Entities;

namespace RO.DevTest.API.Controllers // Mantido conforme o padrão existente
{
    [Route("api/[controller]")]
    [ApiController]
    public class SaleController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly ISaleRepository _saleRepository;
        
        public SaleController(IMediator mediator, ISaleRepository saleRepository)
        {
            _saleRepository = saleRepository;
            _mediator = mediator;
        }
        
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Sale>>> GetAll() // Corrigido: Sales → Sale
        {
            var sales = await _saleRepository.GetAllAsync();
            return Ok(sales);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Sale>> GetById(Guid id)
        {
            var sale = await _saleRepository.GetByIdAsync(id);
            if (sale == null)
                return NotFound();
            return Ok(sale);
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