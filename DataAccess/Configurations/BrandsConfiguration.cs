using DataAccess.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DataAccess.Configurations
{
    public class BrandsConfiguration : IEntityTypeConfiguration<BrandEntity>
    {
        public void Configure(EntityTypeBuilder<BrandEntity> builder)
        {
            builder.HasKey(b => b.Id);

            builder.HasMany(b => b.Products).WithOne(p => p.Brand).HasForeignKey(p => p.BrandId);
        }
    }
}
