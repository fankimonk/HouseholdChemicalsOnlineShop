using API.Helpers;
using System.ComponentModel.DataAnnotations;

namespace API.Contracts.Product
{
    public record CreateProductRequest(
        [Required]
        [MinLength(5, ErrorMessage = "Product name must have at least 5 characters")]
        string Name,

        [Required]
        string Description,

        [Required]
        [ImageValidation]
        IFormFile Image,

        [Required]
        [Range(0.0d, 10000.0d, ErrorMessage = "Price must not be less than 0 and more than 10000")]
        decimal Price,

        [Required]
        [Range(0, int.MaxValue, ErrorMessage = "Stock quantity must not be less than 0")]
        int StockQuantity,

        [Required]
        int CategoryId,

        [Required]
        int BrandId
        );
}
