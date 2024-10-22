using DataAccess.Models;

namespace DataAccess.Interfaces
{
    public interface IBrandsRepository
    {
        Task<List<Brand>> GetAllAsync();
        Task<Brand?> GetByIdAsync(int id);
        Task<Brand?> CreateAsync(Brand brand);
        Task<Brand?> UpdateAsync(int id, Brand brand);
        Task DeleteAsync(int id);
    }
}
