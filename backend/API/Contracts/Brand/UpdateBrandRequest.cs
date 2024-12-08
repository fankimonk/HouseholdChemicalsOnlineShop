using System.ComponentModel.DataAnnotations;

namespace API.Contracts.Brand
{
    public record UpdateBrandRequest(
        [Required]
        [MinLength(3, ErrorMessage = "Brand name must have at least 5 characters")]
        string Name
        );
}
