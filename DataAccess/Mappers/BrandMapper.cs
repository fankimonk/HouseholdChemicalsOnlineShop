using DataAccess.Models;
using DataAccess.DTOs.Brand;

namespace DataAccess.Mappers
{
    public static class BrandMapper
    {
        public static BrandDTO ToDTO(this Brand brand)
        {
            return new BrandDTO
            {
                Id = brand.Id,
                Name = brand.Name
            };
        }

        public static Brand ToBrand(this CreateBrandRequest brandDTO)
        {
            return new Brand
            {
                Name = brandDTO.Name
            };
        }

        public static Brand ToBrand(this UpdateBrandRequest brandDTO)
        {
            return new Brand
            {
                Name = brandDTO.Name
            };
        }
    }
}
