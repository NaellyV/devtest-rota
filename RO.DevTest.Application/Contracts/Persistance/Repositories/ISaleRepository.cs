using RO.DevTest.Domain.Entities;

namespace RO.DevTest.Application.Contracts.Persistance.Repositories
{
    public interface ISaleRepository : IBaseRepository<Sale>
    {
        Task AddAsync(Sale sale);
        Task<IEnumerable<Sale>> GetSalesByPeriodAsync(DateTime startDate, DateTime endDate);
        Task<IEnumerable<Sale>> GetAllAsync();
        Task<Sale?> GetByIdAsync(Guid id);
    }
}
