using MediatR;
using System;

namespace RO.DevTest.Application.Features.Clients.Commands.UpdateClient
{
    public class UpdateClientCommand : IRequest<Guid>
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = default!;
        public string Email { get; set; } = default!;
    }
}
