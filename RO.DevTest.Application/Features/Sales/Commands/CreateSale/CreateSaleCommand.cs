using MediatR;
using RO.DevTest.Domain.Entities;

namespace RO.DevTest.Application.Features.Sales.Commands
{
    public class CreateSaleCommand : IRequest<Sale>
    {
        public Guid ClientId { get; set; }
        public DateTime SaleDate { get; set; }
        public List<SaleProductDto> Products { get; set; }
    }

    public class SaleProductDto
    {
        public Guid ProductId { get; set; }
        public int Quantity { get; set; }
        public decimal UnitPrice { get; set; }
    }
}
