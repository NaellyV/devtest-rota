using MediatR;
using RO.DevTest.Domain.Entities;

namespace RO.DevTest.Application.Features.Clients.Commands
{
    public class CreateClientCommand : IRequest<Client>
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
    }
}
