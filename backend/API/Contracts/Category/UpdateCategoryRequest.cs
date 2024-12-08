using System.ComponentModel.DataAnnotations;

namespace API.Contracts.Category
{
    public record UpdateCategoryRequest(
        [Required]
        [MinLength(5, ErrorMessage = "Category name must have at least 5 characters")]
        string Name
        );
}
