using Domain.Models;
using Microsoft.AspNetCore.Http;

namespace Application.Interfaces
{
    public interface IProductsService
    {
        Task<Product?> CreateProduct(string name, string description, IFormFile image, 
            decimal price, int stockQuantity, int categoryId, int brandId, string imageDirectoryPath);
    }
}