using RO.DevTest.Domain.Abstract;

namespace RO.DevTest.Domain.Entities
{
    public class Sale : BaseEntity
    {
        public Guid ClientId { get; set; }
        public DateTime SaleDate { get; set; }
        public decimal TotalAmount { get; set; }

        public ICollection<SaleProduct> SaleProducts { get; set; }
    }
}
