using MediatR;
using RO.DevTest.Application.Common.Interfaces;
using System.Threading;
using System.Threading.Tasks;

namespace RO.DevTest.Application.Features.Products.Commands.UpdateProduct
{
    public class UpdateProductCommandHandler : IRequestHandler<UpdateProductCommand, Guid>
    {
        private readonly IApplicationDbContext _context;

        public UpdateProductCommandHandler(IApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Guid> Handle(UpdateProductCommand request, CancellationToken cancellationToken)
        {
            var product = await _context.Products.FindAsync(new object[] { request.Id }, cancellationToken);

            if (product == null)
            {
                throw new KeyNotFoundException("Product not found.");
            }

            product.Name = request.Name;
            product.Price = request.Price;

            await _context.SaveChangesAsync(cancellationToken);

            return product.Id;
        }
    }
}
