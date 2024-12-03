using Application.Interfaces;
using DataAccess.Interfaces;
using Domain.Models;

namespace Application.Services
{
    public class CartsService : ICartsService
    {
        private readonly ICartsRepository _cartsRepository;
        private readonly ICartProductsRepository _cartProductsRepository;

        public CartsService(ICartsRepository cartsRepository, ICartProductsRepository cartProductsRepository)
        {
            _cartsRepository = cartsRepository;
            _cartProductsRepository = cartProductsRepository;
        }

        public async Task<List<Product>> GetProducts(int userId)
        {
            var cart = await _cartsRepository.GetByUserIdAsync(userId);
            return await _cartProductsRepository.GetProductsAsync(cart!.Id);
        }

        public async Task<CartProduct?> AddProduct(int userId, int productId)
        {
            var cart = await _cartsRepository.GetByUserIdAsync(userId);
            return await _cartProductsRepository.AddProductAsync(cart!.Id, productId);
        }

        public async Task DeleteProduct(int userId, int productId)
        {
            var cart = await _cartsRepository.GetByUserIdAsync(userId);
            await _cartProductsRepository.DeleteProductAsync(cart!.Id, productId);
        }
    }
}
