using DataAccess.Models;
using DataAccess.DTOs.Brand;

namespace DataAccess.Mappers
{
    public static class BrandMapper
    {
        public static BrandDTO ToDefaultDTO(this Brand brand)
        {
            return new BrandDTO
            {
                Id = brand.Id,
                Name = brand.Name
            };
        }

        public static Brand ToBrand(this CreateBrandDTO brandDTO)
        {
            return new Brand
            {
                Name = brandDTO.Name
            };
        }

        public static Brand ToBrand(this UpdateBrandDTO brandDTO)
        {
            return new Brand
            {
                Name = brandDTO.Name
            };
        }
    }
}
