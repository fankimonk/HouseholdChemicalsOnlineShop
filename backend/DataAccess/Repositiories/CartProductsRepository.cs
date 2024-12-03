using DataAccess.Interfaces;
using Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Repositiories
{
    public class CartProductsRepository : ICartProductsRepository
    {
        private readonly OnlineShopDbContext _dbContext;

        public CartProductsRepository(OnlineShopDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<CartProduct?> AddProductAsync(int cartId, int productId)
        {
            if (await _dbContext.CartProducts.AnyAsync(cp => cp.CartId == cartId && cp.ProductId == productId))
                return null;

            var cartProduct = await _dbContext.CartProducts.AddAsync(new CartProduct { CartId = cartId, ProductId = productId });
            if (cartProduct == null) return null;

            await _dbContext.SaveChangesAsync();
            return cartProduct.Entity;

        }

        public async Task DeleteProductAsync(int cartId, int productId)
        {
            await _dbContext.CartProducts.Where(cp => cp.CartId == cartId && cp.ProductId == productId).ExecuteDeleteAsync();
            await _dbContext.SaveChangesAsync();
        }

        public async Task<List<Product>> GetProductsAsync(int cartId)
        {
            var products = await _dbContext.CartProducts.AsNoTracking()
                .Where(cp => cp.CartId == cartId)
                .Select(cp => cp.Product)
                .ToListAsync();
            return products!;
        }
    }
}
