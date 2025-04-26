using Microsoft.AspNetCore.Mvc;
using RO.DevTest.Application.Contracts.Persistance.Repositories;
using RO.DevTest.Domain.Entities;
using RO.DevTest.Application.Features.Clients.Commands;
using RO.DevTest.Application.Features.Clients.Commands.UpdateClient;
using RO.DevTest.Application.Features.Clients.Commands.DeleteClient;
using MediatR;

namespace RO.DevTest.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClientController : ControllerBase
    {
        private readonly IClientRepository _clientRepository;
        private readonly IMediator _mediator;

        public ClientController(IClientRepository clientRepository, IMediator mediator)
        {
            _clientRepository = clientRepository;
            _mediator = mediator;
        }

        [HttpGet]
public async Task<ActionResult<IEnumerable<Client>>> GetAll()
{
    var userIdClaim = User.FindFirst("sub")?.Value;

    if (userIdClaim == null)
        return Unauthorized();

    var userId = Guid.Parse(userIdClaim);

    var clients = await _clientRepository.GetAllByUserIdAsync(userId); // <- Aqui você buscaria os clientes do user

    return Ok(clients);
}


        [HttpGet("{id}")]
        public async Task<ActionResult<Client>> GetById(Guid id)
        {
            var client = await _clientRepository.GetByIdAsync(id);
            if (client == null)
                return NotFound();
            return Ok(client);
        }

        [HttpPost]
        public async Task<ActionResult<Client>> Create([FromBody] CreateClientCommand command)
        {
            var result = await _mediator.Send(command);
            return Ok(result);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(Guid id, [FromBody] UpdateClientCommand command)
        {
            if (id != command.Id)
                return BadRequest("Id mismatch");

            await _mediator.Send(command);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            await _mediator.Send(new DeleteClientCommand { Id = id });
            return NoContent();
        }
    }
}
