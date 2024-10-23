using DataAccess.Models;

namespace API.Interfaces
{
    public interface IJwtProvider
    {
        string GenerateToken(User user);
    }
}