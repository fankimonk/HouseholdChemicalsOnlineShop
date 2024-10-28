using DataAccess.Models;

namespace DataAccess.Interfaces
{
    public interface IBrandsRepository
    {
        Task<List<BrandEntity>> GetAllAsync();
        Task<BrandEntity?> GetByIdAsync(int id);
        Task<BrandEntity?> CreateAsync(BrandEntity brand);
        Task<BrandEntity?> UpdateAsync(int id, BrandEntity brand);
        Task DeleteAsync(int id);
    }
}
