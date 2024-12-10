using Application.Interfaces;
using DataAccess.Interfaces;
using Domain.Models;
using Microsoft.AspNetCore.Http;

namespace Application.Services
{
    public class ProductsService : IProductsService
    {
        private readonly IProductsRepository _productsRepository;

        public ProductsService(IProductsRepository productsRepo)
        {
            _productsRepository = productsRepo;
        }

        public async Task<Product?> CreateProduct(string name, string description, IFormFile image,
            decimal price, int stockQuantity, int categoryId, int brandId, string webRootPath)
        {
            if (image.Length < 0) return null;

            var filePath = Path.Combine(webRootPath, "images", image.FileName);
            if (!File.Exists(filePath))
                using (var stream = File.Create(filePath))
                    await image.CopyToAsync(stream);

            var product = new Product
            {
                Name = name,
                Description = description,
                ImagePath = "/" + image.FileName,
                Price = price,
                StockQuantity = stockQuantity,
                CategoryId = categoryId,
                BrandId = brandId
            };

            var createdProduct = await _productsRepository.CreateAsync(product);
            return createdProduct;
        }
    }
}
