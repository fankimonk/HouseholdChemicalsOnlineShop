using DataAccess.Interfaces;
using DataAccess.Queries;
using Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;

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

        public async Task<List<Product>> GetAllAsync(ProductsQuery query)
        {
            var productsQueryable = _dbContext.Products.AsNoTracking();

            if (query.SearchQuery.IsNullOrEmpty() == false)
                productsQueryable = productsQueryable.Where(p => p.Name.Contains(query.SearchQuery));

            if (query.CategoryIds.Length != 0)
                productsQueryable = productsQueryable.Where(p => query.CategoryIds.Contains(p.CategoryId));

            if (query.BrandIds.Length != 0)
                productsQueryable = productsQueryable.Where(p => query.BrandIds.Contains(p.BrandId));

            var skipNumber = (query.PageNumber - 1) * query.PageSize;

            return await productsQueryable.Skip(skipNumber).Take(query.PageSize).ToListAsync();
        }

        public async Task<Product?> GetByIdAsync(int id)
        {
            return await _dbContext.Products.AsNoTracking().FirstOrDefaultAsync(p => p.Id == id);
        }

        public async Task<List<Product>> GetByIdsAsync(int[] ids)
        {
            return await _dbContext.Products.AsNoTracking().Where(p => ids.Contains(p.Id)).ToListAsync();
        }

        public async Task<bool> TryDecrementStockQuantities(int[] productIds)
        {
            await _dbContext.BeginTranscationAsync();

            foreach (var productId in productIds)
            {
                var product = await _dbContext.Products.FirstOrDefaultAsync(p => p.Id == productId);
                if (product == null || product.StockQuantity <= 0)
                {
                    await _dbContext.RollbackAsync();
                    return false;
                }
                product.StockQuantity -= 1;
            }

            await _dbContext.SaveChangesAsync();
            await _dbContext.CommitAsync();

            return true;
        }

        public async Task<Product?> UpdateAsync(int id, Product product)
        {
            var updatedProduct = await _dbContext.Products.FirstOrDefaultAsync(p => p.Id == id);
            if (updatedProduct == null) return null;

            updatedProduct.Name = product.Name;
            updatedProduct.Description = product.Description;
            updatedProduct.Price = product.Price;
            updatedProduct.StockQuantity = product.StockQuantity;
            updatedProduct.CategoryId = product.CategoryId;
            updatedProduct.BrandId = product.BrandId;
            await _dbContext.SaveChangesAsync();
            return updatedProduct;
        }
    }
}
