using DataAccess.Models;
using DataAccess.DTOs.Brand;

namespace DataAccess.Mappers
{
    public static class BrandMapper
    {
        public static BrandDTO ToDTO(this BrandEntity brand)
        {
            return new BrandDTO
            {
                Id = brand.Id,
                Name = brand.Name
            };
        }

        public static BrandEntity ToBrand(this CreateBrandRequest brandDTO)
        {
            return new BrandEntity
            {
                Name = brandDTO.Name
            };
        }

        public static BrandEntity ToBrand(this UpdateBrandRequest brandDTO)
        {
            return new BrandEntity
            {
                Name = brandDTO.Name
            };
        }
    }
}
