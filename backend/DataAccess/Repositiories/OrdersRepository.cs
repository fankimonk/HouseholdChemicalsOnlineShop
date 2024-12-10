using DataAccess.Interfaces;
using Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Repositiories
{
    public class OrdersRepository : IOrdersRepository
    {
        private readonly OnlineShopDbContext _dbContext;

        public OrdersRepository(OnlineShopDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<Order?> CreateAsync(Order order)
        {
            var createdOrder = await _dbContext.Orders.AddAsync(order);
            if (createdOrder == null) return null;
            await _dbContext.SaveChangesAsync();
            return createdOrder.Entity;
        }

        public async Task DeleteAsync(int id)
        {
            await _dbContext.Orders.Where(o => o.Id == id).ExecuteDeleteAsync();
            await _dbContext.SaveChangesAsync();
        }

        public async Task<Order?> GetByIdAsync(int id)
        {
            return await _dbContext.Orders.AsNoTracking().FirstOrDefaultAsync(o => o.Id == id);
        }

        public async Task<List<Order>?> GetByUserIdAsync(int userId)
        {
            var cart = await _dbContext.Carts.AsNoTracking().FirstOrDefaultAsync(c => c.UserId == userId);
            if (cart == null) return null;

            return await _dbContext.Orders.AsNoTracking().Where(o => o.CartId == cart.Id).ToListAsync();
        }
    }
}
