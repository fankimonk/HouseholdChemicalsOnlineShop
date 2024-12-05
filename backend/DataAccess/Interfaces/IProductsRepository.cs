using DataAccess.Queries;
using Domain.Models;

namespace DataAccess.Interfaces
{
    public interface IProductsRepository
    {
        Task<List<Product>> GetAllAsync();
        Task<List<Product>> GetAllAsync(ProductsQuery query);
        Task<Product?> GetByIdAsync(int id);
        Task<Product?> CreateAsync(Product product);
        Task<Product?> UpdateAsync(int id, Product product);
        Task DeleteAsync(int id);
    }
}
