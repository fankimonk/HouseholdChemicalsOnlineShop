using DataAccess.Interfaces;
using Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Repositiories
{
    public class CartsRepository : ICartsRepository
    {
        private readonly OnlineShopDbContext _dbContext;

        public CartsRepository(OnlineShopDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<Cart?> CreateAsync(Cart cart)
        {
            var createdCart = await _dbContext.Carts.AddAsync(cart);
            if (createdCart == null) return null;
            await _dbContext.SaveChangesAsync();
            return createdCart.Entity;
        }

        public async Task DeleteAsync(int id)
        {
            await _dbContext.Carts.Where(c => c.Id == id).ExecuteDeleteAsync();
            await _dbContext.SaveChangesAsync();
        }

        public async Task<Cart?> GetByIdAsync(int id)
        {
            return await _dbContext.Carts.AsNoTracking().FirstOrDefaultAsync(c => c.Id == id);
        }

        public async Task<Cart?> GetByUserIdAsync(int userId)
        {
            return await _dbContext.Carts.AsNoTracking().FirstOrDefaultAsync(c => c.UserId == userId);
        }
    }
}
