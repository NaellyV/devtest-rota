using MediatR;
using RO.DevTest.Domain.Entities;

namespace RO.DevTest.Application.Features.Products.Commands
{
    public class CreateProductCommand : IRequest<Product>
    {
        public string Name { get; set; }
        public decimal Price { get; set; }
    }
}
