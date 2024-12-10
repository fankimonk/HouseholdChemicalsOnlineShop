using API.Contracts.Product;
using Domain.Models;

namespace API.Mappers
{
    public static class ProductMapper
    {
        public static ProductResponse ToResponse(this Product product)
        {
            return new ProductResponse(
                product.Id,
                product.Name,
                product.Description,
                product.ImagePath,
                product.Price,
                product.StockQuantity,
                product.CategoryId,
                product.BrandId
            );
        }
    }
}
