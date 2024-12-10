using Domain.Models;

namespace DataAccess.Interfaces
{
    public interface IOrdersRepository
    {
        Task<Order?> GetByIdAsync(int id);
        Task<List<Order>?> GetByUserIdAsync(int userId);
        Task<Order?> CreateAsync(Order order);
        Task DeleteAsync(int id);
    }
}
