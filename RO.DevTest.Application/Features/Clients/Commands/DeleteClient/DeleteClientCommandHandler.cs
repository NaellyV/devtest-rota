using MediatR;
using RO.DevTest.Application.Common.Interfaces;
using System.Threading;
using System.Threading.Tasks;

namespace RO.DevTest.Application.Features.Clients.Commands.DeleteClient
{
    public class DeleteClientCommandHandler : IRequestHandler<DeleteClientCommand, Guid>
    {
        private readonly IApplicationDbContext _context;

        public DeleteClientCommandHandler(IApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Guid> Handle(DeleteClientCommand request, CancellationToken cancellationToken)
        {
            var client = await _context.Clients.FindAsync(new object[] { request.Id }, cancellationToken);

            if (client == null)
            {
                throw new KeyNotFoundException("Client not found.");
            }

            _context.Clients.Remove(client);
            await _context.SaveChangesAsync(cancellationToken);

            return request.Id;
        }
    }
}
