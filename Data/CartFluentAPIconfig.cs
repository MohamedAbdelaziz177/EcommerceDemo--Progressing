using E_Commerce.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace E_Commerce.Data
{
    public class CartFluentAPIconfig : IEntityTypeConfiguration<Cart>
    {
        public void Configure(EntityTypeBuilder<Cart> builder)
        {
            builder.HasKey(x => x.CartId);

            builder.HasOne(x => x.Product)
                  .WithMany()
                  .HasForeignKey(x => x.ProductId);
                  

            /*
            
            builder.HasOne(x => x.Customer)
                   .WithMany()
                   .HasForeignKey(x => x.CustomerId);
            
            */


        }
    }
}
