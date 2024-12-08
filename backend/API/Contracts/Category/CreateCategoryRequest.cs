using System.ComponentModel.DataAnnotations;

namespace API.Contracts.Category
{
    public record CreateCategoryRequest(
        [Required]
        [MinLength(5, ErrorMessage = "Category name must have at least 5 characters")]
        string Name
        );
}
