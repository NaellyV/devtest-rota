using MediatR;
using RO.DevTest.Application.Common.Interfaces;
using System.Threading;
using System.Threading.Tasks;

namespace RO.DevTest.Application.Features.Sales.Commands.DeleteSale
{
    public class DeleteSaleCommandHandler : IRequestHandler<DeleteSaleCommand, Guid>
    {
        private readonly IApplicationDbContext _context;

        public DeleteSaleCommandHandler(IApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Guid> Handle(DeleteSaleCommand request, CancellationToken cancellationToken)
        {
            var sale = await _context.Sales.FindAsync(new object[] { request.Id }, cancellationToken);

            if (sale == null)
            {
                throw new KeyNotFoundException("Sale not found.");
            }

            _context.Sales.Remove(sale);
            await _context.SaveChangesAsync(cancellationToken);

            return request.Id;
        }
    }
}
