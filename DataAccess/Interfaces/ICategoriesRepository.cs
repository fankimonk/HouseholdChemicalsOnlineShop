using DataAccess.Models;

namespace DataAccess.Interfaces
{
    public interface ICategoriesRepository
    {
        Task<List<Category>> GetAllAsync();
        Task<Category?> GetByIdAsync(int id);
        Task<Category?> CreateAsync(Category category);
        Task<Category?> UpdateAsync(int id, Category category);
        Task DeleteAsync(int id);
    }
}
