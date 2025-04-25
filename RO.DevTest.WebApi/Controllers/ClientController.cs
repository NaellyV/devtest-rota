using MediatR;
using Microsoft.AspNetCore.Mvc;
using RO.DevTest.Application.Features.Clients.Commands.CreateClient;
using RO.DevTest.Application.Features.Clients.Commands.UpdateClient;
using RO.DevTest.Application.Features.Clients.Commands.DeleteClient;
using RO.DevTest.Domain.Entities;

namespace RO.DevTest.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClientController : ControllerBase
    {
        private readonly IMediator _mediator;

        public ClientController(IMediator mediator)
        {
            _mediator = mediator;
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
