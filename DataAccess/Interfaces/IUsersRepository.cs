using DataAccess.Models;

namespace DataAccess.Interfaces
{
    public interface IUsersRepository
    {
        Task<List<User>> GetAllAsync();
        Task<User?> GetByIdAsync(int id);
        Task<User?> GetByEmailAsync(string email);
        Task<User?> CreateAsync(User user);
        Task<User?> UpdateAsync(int id, User user);
        Task DeleteAsync(int id);
    }
}
