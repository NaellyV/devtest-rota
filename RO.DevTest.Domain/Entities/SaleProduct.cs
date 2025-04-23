using RO.DevTest.Domain.Abstract;

namespace RO.DevTest.Domain.Entities
{
    public class SaleProduct : BaseEntity
    {
        public required Guid SaleId { get; set; }
        public required Guid ProductId { get; set; }
        public required int Quantity { get; set; }
        public required decimal UnitPrice { get; set; }
        
        public virtual Sale Sale { get; set; } = null!;
        public virtual Product Product { get; set; } = null!;
    }
}