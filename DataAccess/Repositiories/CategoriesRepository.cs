using DataAccess.Interfaces;
using DataAccess.Models;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Repositiories
{
    public class CategoriesRepository : ICategoriesRepository
    {
        private readonly OnlineShopDbContext _dbContext;

        public CategoriesRepository(OnlineShopDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<Category?> CreateAsync(Category category)
        {
            if (category == null) return null;
            await _dbContext.Categories.AddAsync(category);
            await _dbContext.SaveChangesAsync();
            return category;
        }

        public async Task DeleteAsync(int id)
        {
            await _dbContext.Categories.Where(c => c.Id == id).ExecuteDeleteAsync();
            await _dbContext.SaveChangesAsync();
        }

        public async Task<List<Category>> GetAllAsync()
        {
            return await _dbContext.Categories.AsNoTracking().ToListAsync();
        }

        public async Task<Category?> GetByIdAsync(int id)
        {
            return await _dbContext.Categories.AsNoTracking().FirstOrDefaultAsync(c => c.Id == id);
        }

        public async Task<Category?> UpdateAsync(int id, Category category)
        {
            var affectedRows = await _dbContext.Categories.Where(c => c.Id == id).ExecuteUpdateAsync(s => s
                .SetProperty(c => c.Name, category.Name));
            if (affectedRows == 0)
                return null;
            await _dbContext.SaveChangesAsync();
            return category;
        }
    }
}
