using MediatR;
using System;

namespace RO.DevTest.Application.Features.Clients.Commands.DeleteClient
{
    public class DeleteClientCommand : IRequest<Guid>
    {
        public Guid Id { get; set; }
    }
}
