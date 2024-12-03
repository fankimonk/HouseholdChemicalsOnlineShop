using Domain.Models;

namespace DataAccess.Interfaces
{
    public interface ICartsRepository
    {
        Task<Cart?> GetByIdAsync(int id);
        Task<Cart?> GetByUserIdAsync(int userId);
        Task<Cart?> CreateAsync(Cart cart);
        Task DeleteAsync(int id);
    }
}
