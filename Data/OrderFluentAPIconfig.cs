using E_Commerce.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.Reflection.Emit;

namespace E_Commerce.Data
{
    public class OrderFluentAPIconfig : IEntityTypeConfiguration<Order>
    {
        public void Configure(EntityTypeBuilder<Order> builder)
        {
            builder.HasKey(x => x.OrderId);

            builder.HasOne(x => x.Customer)
                   .WithMany(x => x.Orders)
                   .HasForeignKey(x => x.CustomerId);

            builder.HasMany(x => x.OrderItems)
                   .WithOne(x => x.Order)
                   .HasForeignKey(x => x.OrderId);

            builder.HasOne(x => x.Payment)
                   .WithOne(x => x.Order)
                   .HasForeignKey<Payment>(p => p.OrderId);

            builder.Property(o => o.TotalAmount)
                   .HasColumnType("decimal(18,2)");



        }
    }
}
