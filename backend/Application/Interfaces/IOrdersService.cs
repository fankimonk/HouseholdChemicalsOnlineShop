using Domain.Models;

namespace Application.Interfaces
{
    public interface IOrdersService
    {
        Task<Order?> CreateOrder(int userId, string shippingAddress, int[] productIds);
    }
}