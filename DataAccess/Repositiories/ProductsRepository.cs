using DataAccess.Interfaces;
using Domain.Models;
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
            var createdProduct = await _dbContext.Products.AddAsync(product);
            if (createdProduct == null) return null;
            await _dbContext.SaveChangesAsync();
            return createdProduct.Entity;
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
            var updatedProduct = await _dbContext.Products.FirstOrDefaultAsync(p => p.Id == id);
            if (updatedProduct == null) return null;

            updatedProduct.Name = product.Name;
            updatedProduct.Description = product.Description;
            updatedProduct.ImageURL = product.ImageURL;
            updatedProduct.Price = product.Price;
            updatedProduct.StockQuantity = product.StockQuantity;
            updatedProduct.CategoryId = product.CategoryId;
            updatedProduct.BrandId = product.BrandId;
            await _dbContext.SaveChangesAsync();
            return updatedProduct;
        }
    }
}
