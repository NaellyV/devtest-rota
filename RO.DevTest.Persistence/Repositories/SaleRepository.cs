using Microsoft.EntityFrameworkCore;
using RO.DevTest.Application.Contracts.Persistance.Repositories;
using RO.DevTest.Domain.Entities;
using RO.DevTest.Persistence;

namespace RO.DevTest.Persistence.Repositories
{
    public class SaleRepository : BaseRepository<Sale>, ISaleRepository
    {
        public SaleRepository(DefaultContext context) : base(context) { }

        // Implementação do AddAsync específico
        public async Task AddAsync(Sale sale)
        {
            await _context.Sales.AddAsync(sale);
            await _context.SaveChangesAsync();
        }

        // Implementação do método personalizado
       public async Task<IEnumerable<Sale>> GetSalesByPeriodAsync(DateTime startDate, DateTime endDate)
{
    return await _context.Sales
        .Where(s => s.SaleDate >= startDate && s.SaleDate <= endDate)
        .Include(s => s.SaleProducts)
            .ThenInclude(sp => sp.Product) // Agora funciona!
        .ToListAsync();
}
    }
}