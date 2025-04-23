using MediatR;
using RO.DevTest.Application.Contracts.Persistance.Repositories;
using RO.DevTest.Domain.Entities;

namespace RO.DevTest.Application.Features.Sales.Commands
{
    public class CreateSaleCommandHandler : IRequestHandler<CreateSaleCommand, Sale>
    {
        private readonly ISaleRepository _saleRepository;
        private readonly ISaleProductRepository _saleProductRepository;

        public CreateSaleCommandHandler(ISaleRepository saleRepository, ISaleProductRepository saleProductRepository)
        {
            _saleRepository = saleRepository;
            _saleProductRepository = saleProductRepository;
        }

        public async Task<Sale> Handle(CreateSaleCommand request, CancellationToken cancellationToken)
        {
            var sale = new Sale
            {
                Id = Guid.NewGuid(),
                ClientId = request.ClientId,
                SaleDate = request.SaleDate,
                TotalAmount = request.Products.Sum(p => p.Quantity * p.UnitPrice),
                SaleProducts = new List<SaleProduct>()
            };

            // Primeiro cria a venda (sale)
            sale = await _saleRepository.CreateAsync(sale, cancellationToken);

            foreach (var p in request.Products)
            {
                var saleProduct = new SaleProduct
                {
                    Id = Guid.NewGuid(),
                    SaleId = sale.Id,
                    ProductId = p.ProductId,
                    Quantity = p.Quantity,
                    UnitPrice = p.UnitPrice
                };

                await _saleProductRepository.CreateAsync(saleProduct, cancellationToken);
                sale.SaleProducts.Add(saleProduct);
            }

            return sale;
        }
    }
}