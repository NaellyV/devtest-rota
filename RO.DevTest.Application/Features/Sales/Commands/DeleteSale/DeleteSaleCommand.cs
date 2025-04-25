using MediatR;
using System;

namespace RO.DevTest.Application.Features.Sales.Commands.DeleteSale
{
    public class DeleteSaleCommand : IRequest<Guid>
    {
        public Guid Id { get; set; }
    }
}
