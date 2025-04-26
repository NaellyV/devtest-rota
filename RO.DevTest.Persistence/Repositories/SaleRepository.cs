using Microsoft.EntityFrameworkCore;
using RO.DevTest.Application.Contracts.Persistance.Repositories;
using RO.DevTest.Domain.Entities;
using RO.DevTest.Persistence;

namespace RO.DevTest.Persistence.Repositories
{
    public class SaleRepository : BaseRepository<Sale>, ISaleRepository
    {
        public SaleRepository(DefaultContext context) : base(context) { }

        public async Task AddAsync(Sale sale)
        {
            await _context.Sales.AddAsync(sale);
            await _context.SaveChangesAsync();
        }

       public async Task<IEnumerable<Sale>> GetSalesByPeriodAsync(DateTime startDate, DateTime endDate)
        {
            return await _context.Sales
                .Where(s => s.SaleDate >= startDate && s.SaleDate <= endDate)
                .Include(s => s.SaleProducts)
                    .ThenInclude(sp => sp.Product) 
                .ToListAsync();
        }


         public async Task<IEnumerable<Sale>> GetAllAsync()
        {
            return await _context.Sales.ToListAsync();

        }

        public async Task<Sale?> GetByIdAsync(Guid id)
        {
            return await _context.Sales.FindAsync(id);

        }
    }
}