using Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DataAccess.Configurations
{
    public class OrdersConfiguration : IEntityTypeConfiguration<Order>
    {
        public void Configure(EntityTypeBuilder<Order> builder)
        {
            builder.HasKey(o => o.Id);

            builder.Property(o => o.TotalPrice).HasColumnType("decimal(18,2)");

            builder.HasOne(o => o.Cart).WithMany(c => c.Orders).HasForeignKey(o => o.CartId);
        }
    }
}
