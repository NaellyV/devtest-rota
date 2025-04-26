using RO.DevTest.Domain.Abstract;

namespace RO.DevTest.Domain.Entities
{
    public class Client : BaseEntity
    {
        public required string Name { get; set; }
        public required string Email { get; set; }
        public required string Phone { get; set; }

        public Guid UserId { get; set; }
    }
}
