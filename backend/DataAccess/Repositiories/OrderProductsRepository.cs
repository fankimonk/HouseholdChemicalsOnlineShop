using DataAccess.Interfaces;
using Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Repositiories
{
    public class OrderProductsRepository : IOrderProductsRepository
    {
        private readonly OnlineShopDbContext _dbContext;

        public OrderProductsRepository(OnlineShopDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<List<Product>> GetProductsAsync(int orderId)
        {
            return await _dbContext.OrderProducts.Include(op => op.Product).AsNoTracking()
                .Where(op => op.OrderId == orderId).Select(op => op.Product!).ToListAsync();
        }
    }
}
