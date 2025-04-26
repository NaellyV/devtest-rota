using RO.DevTest.Application.Contracts.Persistance.Repositories;
using RO.DevTest.Domain.Entities;
using Microsoft.EntityFrameworkCore;


namespace RO.DevTest.Persistence.Repositories
{
    public class ClientRepository : BaseRepository<Client>, IClientRepository
    {
        public ClientRepository(DefaultContext context) : base(context) { }

        public async Task<IEnumerable<Client>> GetAllAsync()
        {
            return await _context.Clients.ToListAsync();
        }

        public async Task<Client?> GetByIdAsync(Guid id)
        {
            return await _context.Clients.FindAsync(id);
        }

       public async Task<IEnumerable<Client>> GetAllByUserIdAsync(Guid userId)
{
    return await _context.Clients
        .Where(c => c.UserId == userId)
        .ToListAsync();
}


    }
    
}
