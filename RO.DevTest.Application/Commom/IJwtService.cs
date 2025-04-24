using RO.DevTest.Domain.Entities;

namespace RO.DevTest.Application.Common.Interfaces;

public interface IJwtService
{
    string GenerateToken(User user);
}
