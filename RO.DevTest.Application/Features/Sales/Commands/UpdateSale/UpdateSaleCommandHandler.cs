using MediatR;
using Microsoft.EntityFrameworkCore;
using RO.DevTest.Application.Common.Interfaces;
using RO.DevTest.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace RO.DevTest.Application.Features.Sales.Commands.UpdateSale
{
    public class UpdateSaleCommandHandler : IRequestHandler<UpdateSaleCommand, Guid>
    {
        private readonly IApplicationDbContext _context;

        public UpdateSaleCommandHandler(IApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Guid> Handle(UpdateSaleCommand request, CancellationToken cancellationToken)
        {
            var sale = await _context.Sales
                .Include(s => s.SaleProducts)
                .FirstOrDefaultAsync(s => s.Id == request.Id, cancellationToken);

            if (sale == null)
                throw new KeyNotFoundException("Sale not found.");

            // Atualiza o cliente da venda
            sale.ClientId = request.ClientId;

            // Remove produtos antigos da venda
            _context.SaleProducts.RemoveRange(sale.SaleProducts);

            // Adiciona os novos produtos
            sale.SaleProducts = request.Products.Select(p => new SaleProduct
            {
                SaleId = sale.Id,
                ProductId = p.ProductId,
                Quantity = p.Quantity,
                UnitPrice = p.UnitPrice
            }).ToList();

            // Recalcula o valor total
            sale.TotalAmount = sale.SaleProducts.Sum(p => p.Quantity * p.UnitPrice);

            await _context.SaveChangesAsync(cancellationToken);

            return sale.Id;
        }
    }
}
