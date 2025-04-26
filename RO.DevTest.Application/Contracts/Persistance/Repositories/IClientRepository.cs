using RO.DevTest.Domain.Entities;

namespace RO.DevTest.Application.Contracts.Persistance.Repositories
{
    public interface IClientRepository : IBaseRepository<Client>
    {
        Task<IEnumerable<Client>> GetAllAsync();
        Task<Client?> GetByIdAsync(Guid id);

    Task<IEnumerable<Client>> GetAllByUserIdAsync(Guid userId);

    }
}
