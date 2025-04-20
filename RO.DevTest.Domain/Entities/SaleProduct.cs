using RO.DevTest.Domain.Abstract;

namespace RO.DevTest.Domain.Entities
{
    public class SaleProduct : BaseEntity
    {
        public Guid SaleId { get; set; }
        public Guid ProductId { get; set; }
        public int Quantity { get; set; }
        public decimal UnitPrice { get; set; }
    }
}
