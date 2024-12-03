using Domain.Models;

namespace Application.Interfaces
{
    public interface ICartsService
    {
        Task<CartProduct?> AddProduct(int userId, int productId);
        Task DeleteProduct(int userId, int productId);
        Task<List<Product>> GetProducts(int userId);
    }
}