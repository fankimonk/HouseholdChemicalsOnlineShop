using Domain.Enums;
using Domain.Models;

namespace DataAccess.Interfaces
{
    public interface IUsersRepository
    {
        Task<List<User>> GetAllAsync();
        Task<User?> GetByIdAsync(int id);
        Task<User?> GetByEmailAsync(string email);
        Task<HashSet<Permissions>> GetUserPermissions(int id);
        Task<User?> CreateAsync(User user);
        Task<User?> UpdateAsync(int id, User user);
        Task DeleteAsync(int id);
        Task<bool> UsernameExistsAsync(string userName);
        Task<bool> EmailExistsAsync(string emal);
    }
}
