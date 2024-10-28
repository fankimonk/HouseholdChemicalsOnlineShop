using DataAccess.Models;

namespace DataAccess.Interfaces
{
    public interface ICategoriesRepository
    {
        Task<List<CategoryEntity>> GetAllAsync();
        Task<CategoryEntity?> GetByIdAsync(int id);
        Task<CategoryEntity?> CreateAsync(CategoryEntity category);
        Task<CategoryEntity?> UpdateAsync(int id, CategoryEntity category);
        Task DeleteAsync(int id);
    }
}
