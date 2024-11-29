using DataAccess.Interfaces;
using Domain.Models;
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
            var createdCategory = await _dbContext.Categories.AddAsync(category);
            if (createdCategory == null) return null;
            await _dbContext.SaveChangesAsync();
            return createdCategory.Entity;
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
            var updatedCategory = await _dbContext.Categories.FirstOrDefaultAsync(c => c.Id == id);
            if (updatedCategory == null) return null;

            updatedCategory.Name = category.Name;
            await _dbContext.SaveChangesAsync();
            return updatedCategory;
        }
    }
}
