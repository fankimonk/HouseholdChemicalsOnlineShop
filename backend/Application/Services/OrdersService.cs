using Application.Interfaces;
using DataAccess.Interfaces;
using Domain.Models;

namespace Application.Services
{
    public class OrdersService : IOrdersService
    {
        private readonly IOrdersRepository _ordersRepository;
        private readonly IProductsRepository _productsRepository;
        private readonly ICartsRepository _cartsRepository;

        public OrdersService(IOrdersRepository ordersRepository, IProductsRepository productsRepository, ICartsRepository cartsRepository)
        {
            _ordersRepository = ordersRepository;
            _productsRepository = productsRepository;
            _cartsRepository = cartsRepository;
        }

        public async Task<Order?> CreateOrder(int userId, string shippingAddress, int[] productIds)
        {
            var cart = await _cartsRepository.GetByUserIdAsync(userId);
            if (cart == null) return null;

            var totalPrice = (await _productsRepository.GetByIdsAsync(productIds)).Select(p => p.Price).Sum();

            var order = new Order
            {
                OrderDate = DateTime.Now,
                TotalPrice = totalPrice,
                ShippingAddress = shippingAddress,
                CartId = cart.Id
            };

            foreach (var id in productIds)
                order.OrderProducts.Add(new OrderProduct { Order = order, ProductId = id });

            if (await _productsRepository.TryDecrementStockQuantities(productIds) == false)
                return null;

            return await _ordersRepository.CreateAsync(order);
        }
    }
}
