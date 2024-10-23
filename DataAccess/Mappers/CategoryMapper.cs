using DataAccess.Models.DTOs.Product;
using DataAccess.Models;
using DataAccess.DTOs.Category;

namespace DataAccess.Mappers
{
    public static class CategoryMapper
    {
        public static CategoryDTO ToDTO(this Category category)
        {
            return new CategoryDTO
            {
                Id = category.Id,
                Name = category.Name
            };
        }

        public static Category ToCategory(this CreateCategoryRequest categoryDTO)
        {
            return new Category
            {
                Name = categoryDTO.Name
            };
        }

        public static Category ToCategory(this UpdateCategoryRequest categoryDTO)
        {
            return new Category
            {
                Name = categoryDTO.Name
            };
        }
    }
}
