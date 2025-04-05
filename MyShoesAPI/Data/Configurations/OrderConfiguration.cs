using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MyShoesAPI.Models;

namespace MyShoesAPI.Data.Configurations
{
    public class OrderConfiguration : IEntityTypeConfiguration<Order>
    {
        public void Configure(EntityTypeBuilder<Order> builder)
        {
            builder.HasKey(o => o.Id);
            builder.Property(o => o.UserId).IsRequired();
            builder.Property(o => o.TotalAmount).HasColumnType("decimal(18,2)").IsRequired();
            builder.Property(o => o.CreatedAt).IsRequired();
            builder.Property(o => o.PaymentMethod).IsRequired();

            builder.HasOne(o => o.User)
                .WithMany()
                .HasForeignKey(o => o.UserId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(o => o.ShippingAddress)
                .WithMany()
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
} 