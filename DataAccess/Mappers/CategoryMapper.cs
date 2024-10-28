using DataAccess.Models.DTOs.Product;
using DataAccess.Models;
using DataAccess.DTOs.Category;

namespace DataAccess.Mappers
{
    public static class CategoryMapper
    {
        public static CategoryDTO ToDTO(this CategoryEntity category)
        {
            return new CategoryDTO
            {
                Id = category.Id,
                Name = category.Name
            };
        }

        public static CategoryEntity ToCategory(this CreateCategoryRequest categoryDTO)
        {
            return new CategoryEntity
            {
                Name = categoryDTO.Name
            };
        }

        public static CategoryEntity ToCategory(this UpdateCategoryRequest categoryDTO)
        {
            return new CategoryEntity
            {
                Name = categoryDTO.Name
            };
        }
    }
}
