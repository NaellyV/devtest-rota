using RO.DevTest.Domain.Entities;

namespace RO.DevTest.Application.Contracts.Persistance.Repositories
{
    public interface ISaleRepository : IBaseRepository<Sale>
    {
        Task<IEnumerable<Sale>> GetSalesByPeriodAsync(DateTime startDate, DateTime endDate);
    }
}
