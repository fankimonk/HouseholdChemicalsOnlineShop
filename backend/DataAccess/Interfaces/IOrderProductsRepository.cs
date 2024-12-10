using Domain.Models;

namespace DataAccess.Interfaces
{
    public interface IOrderProductsRepository
    {
        Task<List<Product>> GetProductsAsync(int orderId);
    }
}
