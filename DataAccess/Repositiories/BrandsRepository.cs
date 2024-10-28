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

        public async Task<BrandEntity?> CreateAsync(BrandEntity brand)
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

        public async Task<List<BrandEntity>> GetAllAsync()
        {
            return await _dbContext.Brands.AsNoTracking().ToListAsync();
        }

        public async Task<BrandEntity?> GetByIdAsync(int id)
        {
            return await _dbContext.Brands.AsNoTracking().FirstOrDefaultAsync(b => b.Id == id);
        }

        public async Task<BrandEntity?> UpdateAsync(int id, BrandEntity brand)
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
