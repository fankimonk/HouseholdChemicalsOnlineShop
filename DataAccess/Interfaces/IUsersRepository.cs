using DataAccess.Enums;
using DataAccess.Models;

namespace DataAccess.Interfaces
{
    public interface IUsersRepository
    {
        Task<List<UserEntity>> GetAllAsync();
        Task<UserEntity?> GetByIdAsync(int id);
        Task<UserEntity?> GetByEmailAsync(string email);
        Task<HashSet<Permissions>> GetUserPermissions(int id);
        Task<UserEntity?> CreateAsync(UserEntity user);
        Task<UserEntity?> UpdateAsync(int id, UserEntity user);
        Task DeleteAsync(int id);
    }
}
