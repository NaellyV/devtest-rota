using Microsoft.EntityFrameworkCore;
using RO.DevTest.Domain.Entities;
using System.Threading;
using System.Threading.Tasks;

namespace RO.DevTest.Application.Common.Interfaces
{
    public interface IApplicationDbContext
    {
        DbSet<Client> Clients { get; set; }
        DbSet<Product> Products { get; set; }
        DbSet<Sale> Sales { get; set; }
        DbSet<SaleProduct> SaleProducts { get; set; }

        Task<int> SaveChangesAsync(CancellationToken cancellationToken);
        
    }
}
