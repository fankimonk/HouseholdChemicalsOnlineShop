using DataAccess.Interfaces;
using Domain.Models;
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
            var createdBrand = await _dbContext.Brands.AddAsync(brand);
            if (createdBrand == null) return null;
            await _dbContext.SaveChangesAsync();
            return createdBrand.Entity;
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
            var updatedBrand = await _dbContext.Brands.FirstOrDefaultAsync(b => b.Id == id);
            if (updatedBrand == null) return null;

            updatedBrand.Name = brand.Name;
            await _dbContext.SaveChangesAsync();
            return updatedBrand;
        }
    }
}
