using MediatR;
using Microsoft.AspNetCore.Mvc;
using RO.DevTest.Application.Features.Clients.Commands;
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
    }
}
