using DataAccess.Interfaces;
using DataAccess.Models;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Repositiories
{
    public class BrandsRepository : IBrandsRepository
    {
        private readonly OnlineShopDbContext _dbContext;

        public BrandsRepository(OnlineShopDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<Brand?> CreateAsync(Brand brand)
        {
            if (brand == null) return null;
            await _dbContext.Brands.AddAsync(brand);
            await _dbContext.SaveChangesAsync();
            return brand;
        }

        public async Task DeleteAsync(int id)
        {
            await _dbContext.Brands.Where(b => b.Id == id).ExecuteDeleteAsync();
            await _dbContext.SaveChangesAsync();
        }

        public async Task<List<Brand>> GetAllAsync()
        {
            return await _dbContext.Brands.AsNoTracking().ToListAsync();
        }

        public async Task<Brand?> GetByIdAsync(int id)
        {
            return await _dbContext.Brands.AsNoTracking().FirstOrDefaultAsync(b => b.Id == id);
        }

        public async Task<Brand?> UpdateAsync(int id, Brand brand)
        {
            var affectedRows = await _dbContext.Brands.Where(b => b.Id == id).ExecuteUpdateAsync(s => s
                .SetProperty(b => b.Name, brand.Name));
            if (affectedRows == 0)
                return null;
            await _dbContext.SaveChangesAsync();
            return brand;
        }
    }
}
