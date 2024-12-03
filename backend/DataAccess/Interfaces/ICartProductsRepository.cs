using Domain.Models;

namespace DataAccess.Interfaces
{
    public interface ICartProductsRepository
    {
        Task<List<Product>> GetProductsAsync(int cartId);
        Task<CartProduct?> AddProductAsync(int cartId, int productId);
        Task DeleteProductAsync(int cartId, int productId);
    }
}
