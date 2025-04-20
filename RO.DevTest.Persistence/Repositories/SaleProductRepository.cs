using RO.DevTest.Application.Contracts.Persistance.Repositories;
using RO.DevTest.Domain.Entities;

namespace RO.DevTest.Persistence.Repositories
{
    public class SaleProductRepository : BaseRepository<SaleProduct>, ISaleProductRepository
    {
        public SaleProductRepository(DefaultContext context) : base(context)
        {
        }
    }
}
