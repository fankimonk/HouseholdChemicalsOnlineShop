using DataAccess.Models;
using DataAccess.Models.DTOs.Product;

namespace DataAccess.Mappers
{
    public static class ProductMapper
    {
        public static ProductDTO ToDTO(this Product product)
        {
            return new ProductDTO
            {
                Id = product.Id,
                Name = product.Name,
                Description = product.Description,
                ImageURL = product.ImageURL,
                Price = product.Price,
                StockQuantity = product.StockQuantity,
                CategoryId = product.CategoryId,
                BrandId = product.BrandId,
            };
        }

        public static Product ToProduct(this CreateProductRequest productDTO)
        {
            return new Product
            {
                Name = productDTO.Name,
                Description = productDTO.Description,
                ImageURL = productDTO.ImageURL,
                Price = productDTO.Price,
                StockQuantity = productDTO.StockQuantity,
                CategoryId = productDTO.CategoryId,
                BrandId = productDTO.BrandId
            };
        }

        public static Product ToProduct(this UpdateProductRequest productDTO)
        {
            return new Product
            {
                Name = productDTO.Name,
                Description = productDTO.Description,
                ImageURL = productDTO.ImageURL,
                Price = productDTO.Price,
                StockQuantity = productDTO.StockQuantity,
                CategoryId = productDTO.CategoryId,
                BrandId = productDTO.BrandId
            };
        }
    }
}
