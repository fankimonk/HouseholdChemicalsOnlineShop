using DataAccess.Models;

namespace DataAccess.Interfaces
{
    public interface IProductsRepository
    {
        Task<List<ProductEntity>> GetAllAsync();
        Task<ProductEntity?> GetByIdAsync(int id);
        Task<ProductEntity?> CreateAsync(ProductEntity product);
        Task<ProductEntity?> UpdateAsync(int id, ProductEntity product);
        Task DeleteAsync(int id);
    }
}
