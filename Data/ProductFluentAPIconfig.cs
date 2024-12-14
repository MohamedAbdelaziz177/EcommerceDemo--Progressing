using E_Commerce.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace E_Commerce.Data
{
    public class ProductFluentAPIconfig : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.HasKey(x => x.ProductId);

            builder.HasOne(x => x.category)
                   .WithMany(x => x.Products)
                   .HasForeignKey(x => x.CategoryId);


            builder.HasOne(x => x.brand)
                   .WithMany(x => x.Products)
                   .HasForeignKey(x => x.BrandId);

        }
    }
}
