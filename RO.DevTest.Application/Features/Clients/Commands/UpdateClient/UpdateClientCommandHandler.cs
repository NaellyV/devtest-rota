using MediatR;
using RO.DevTest.Domain.Entities;
using RO.DevTest.Application.Common.Interfaces;
using System.Threading;
using System.Threading.Tasks;

namespace RO.DevTest.Application.Features.Clients.Commands.UpdateClient
{
    public class UpdateClientCommandHandler : IRequestHandler<UpdateClientCommand, Guid>
    {
        private readonly IApplicationDbContext _context;

        public UpdateClientCommandHandler(IApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Guid> Handle(UpdateClientCommand request, CancellationToken cancellationToken)
        {
            var client = await _context.Clients.FindAsync(new object[] { request.Id }, cancellationToken);

            if (client == null)
            {
                throw new KeyNotFoundException("Client not found.");
            }

            client.Name = request.Name;
            client.Email = request.Email;

            await _context.SaveChangesAsync(cancellationToken);

            return client.Id;
        }
    }
}
