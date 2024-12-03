using Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DataAccess.Configurations
{
    public class CartsConfiguration : IEntityTypeConfiguration<Cart>
    {
        public void Configure(EntityTypeBuilder<Cart> builder)
        {
            builder.HasKey(c => c.Id);

            //builder
            //    .HasMany(c => c.Products)
            //    .WithMany(p => p.Carts)
            //    .UsingEntity<CartProduct>(
            //        l => l.HasOne<Product>().WithMany().HasForeignKey(p => p.ProductId),
            //        r => r.HasOne<Cart>().WithMany().HasForeignKey(c => c.CartId));
        }
    }
}
