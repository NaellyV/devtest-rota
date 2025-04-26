using RO.DevTest.Application.Contracts.Persistance.Repositories;
using RO.DevTest.Domain.Entities;
using Microsoft.EntityFrameworkCore;


namespace RO.DevTest.Persistence.Repositories
{
    public class ProductRepository : BaseRepository<Product>, IProductRepository
    {
        public ProductRepository(DefaultContext context) : base(context) { }

         public async Task<IEnumerable<Product>> GetAllAsync()
        {
            return await _context.Products.ToListAsync();

        }

        public async Task<Product?> GetByIdAsync(Guid id)
        {
            return await _context.Products.FindAsync(id);

        }
    }
}
