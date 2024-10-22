using DataAccess.Models.DTOs.Product;
using DataAccess.Models;
using DataAccess.DTOs.Category;

namespace DataAccess.Mappers
{
    public static class CategoryMapper
    {
        public static CategoryDTO ToDefaultDTO(this Category category)
        {
            return new CategoryDTO
            {
                Id = category.Id,
                Name = category.Name
            };
        }

        public static Category ToCategory(this CreateCategoryDTO categoryDTO)
        {
            return new Category
            {
                Name = categoryDTO.Name
            };
        }

        public static Category ToCategory(this UpdateCategoryDTO categoryDTO)
        {
            return new Category
            {
                Name = categoryDTO.Name
            };
        }
    }
}
