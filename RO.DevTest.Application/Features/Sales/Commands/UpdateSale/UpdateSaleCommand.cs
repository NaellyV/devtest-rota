using MediatR;
using System;
using System.Collections.Generic;

// UpdateSaleCommand.cs
namespace RO.DevTest.Application.Features.Sales.Commands.UpdateSale
{
    public class UpdateSaleProductDto  // Nome alterado
    {
        public Guid ProductId { get; set; }
        public int Quantity { get; set; }
        public decimal UnitPrice { get; set; } 
    }

    public class UpdateSaleCommand : IRequest<Guid>
    {
        public Guid Id { get; set; }
        public Guid ClientId { get; set; }
        public List<UpdateSaleProductDto> Products { get; set; } = new();
    }
}