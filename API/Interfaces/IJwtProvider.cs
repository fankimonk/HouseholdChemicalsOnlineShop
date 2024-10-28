using DataAccess.Models;

namespace API.Interfaces
{
    public interface IJwtProvider
    {
        string GenerateToken(UserEntity user);
    }
}