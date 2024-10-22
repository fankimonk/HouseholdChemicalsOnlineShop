using DataAccess.Interfaces;
using DataAccess.Models;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Repositiories
{
    public class ProductsRepository : IProductsRepository
    {
        private readonly OnlineShopDbContext _dbContext;

        public ProductsRepository(OnlineShopDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<Product?> CreateAsync(Product product)
        {
            if (product == null) return null;
            await _dbContext.Products.AddAsync(product);
            await _dbContext.SaveChangesAsync();
            return product;
        }

        public async Task DeleteAsync(int id)
        {
            await _dbContext.Products.Where(p => p.Id == id).ExecuteDeleteAsync();
            await _dbContext.SaveChangesAsync();
        }

        public async Task<List<Product>> GetAllAsync()
        {
            return await _dbContext.Products.AsNoTracking().ToListAsync();
        }

        public async Task<Product?> GetByIdAsync(int id)
        {
            return await _dbContext.Products.AsNoTracking().FirstOrDefaultAsync(p => p.Id == id);
        }

        public async Task<Product?> UpdateAsync(int id, Product product)
        {
            var affectedRows = await _dbContext.Products.Where(p => p.Id == id).ExecuteUpdateAsync(s => s
                .SetProperty(p => p.Name, product.Name)
                .SetProperty(p => p.Description, product.Description)
                .SetProperty(p => p.ImageURL, product.ImageURL)
                .SetProperty(p => p.Price, product.Price)
                .SetProperty(p => p.StockQuantity, product.StockQuantity)
                .SetProperty(p => p.CategoryId, product.CategoryId)
                .SetProperty(p => p.BrandId, product.BrandId));
            if (affectedRows == 0)
                return null;
            await _dbContext.SaveChangesAsync();
            return product;
        }
    }
}
