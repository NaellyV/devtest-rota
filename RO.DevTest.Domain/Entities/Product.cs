using RO.DevTest.Domain.Abstract;

namespace RO.DevTest.Domain.Entities
{
    public class Product : BaseEntity
    {
        public required string Name { get; set; }
        public required decimal Price { get; set; }
    }
}
