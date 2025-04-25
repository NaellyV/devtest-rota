using MediatR;
using System;

namespace RO.DevTest.Application.Features.Products.Commands.DeleteProduct
{
    public class DeleteProductCommand : IRequest<Guid>
    {
        public Guid Id { get; set; }
    }
}
