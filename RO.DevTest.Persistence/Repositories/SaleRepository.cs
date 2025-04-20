using Microsoft.EntityFrameworkCore;
using RO.DevTest.Application.Contracts.Persistance.Repositories;
using RO.DevTest.Domain.Entities;

namespace RO.DevTest.Persistence.Repositories
{
    public class SaleRepository : BaseRepository<Sale>, ISaleRepository
    {
        public SaleRepository(DefaultContext context) : base(context)
        {
        }

        public async Task<IEnumerable<Sale>> GetSalesByPeriodAsync(DateTime startDate, DateTime endDate)
        {
            return await _context.Sales
                .Include(s => s.SaleProducts)
                .Where(s => s.SaleDate >= startDate && s.SaleDate <= endDate)
                .ToListAsync();
        }
    }
}
