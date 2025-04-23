using RO.DevTest.Domain.Abstract;

namespace RO.DevTest.Domain.Entities
{
    public class Sale : BaseEntity
    {
        public required Guid ClientId { get; set; }
        public required DateTime SaleDate { get; set; }
        public required decimal TotalAmount { get; set; }

        public ICollection<SaleProduct> SaleProducts { get; set; } = new List<SaleProduct>();
    }
}
