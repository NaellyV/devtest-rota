using MediatR;
using RO.DevTest.Application.Common.Interfaces;
using System.Threading;
using System.Threading.Tasks;

namespace RO.DevTest.Application.Features.Products.Commands.DeleteProduct
{
    public class DeleteProductCommandHandler : IRequestHandler<DeleteProductCommand, Guid>
    {
        private readonly IApplicationDbContext _context;

        public DeleteProductCommandHandler(IApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Guid> Handle(DeleteProductCommand request, CancellationToken cancellationToken)
        {
            var product = await _context.Products.FindAsync(new object[] { request.Id }, cancellationToken);

            if (product == null)
            {
                throw new KeyNotFoundException("Product not found.");
            }

            _context.Products.Remove(product);
            await _context.SaveChangesAsync(cancellationToken);

            return request.Id;
        }
    }
}
