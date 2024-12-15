using E_Commerce.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace E_Commerce.Data
{
    public class ProductFluentAPIconfig : IEntityTypeConfiguration<Product>
    {
        List<Product> products = new List<Product>()
        {
             new Product { ProductId = 1, Name = "HP Zbook Power G9", Price = 19.99m, StockQuantity = 50, ImageUrl = "", CategoryId = 1, BrandId = 1 },
        new Product { ProductId = 2, Name = "HP Zbook Power G9 ", Price = 29.99m, StockQuantity = 30, ImageUrl = "Imgs/p7", CategoryId = 2, BrandId = 2 },
        new Product { ProductId = 3, Name = "HP Zbook Power G9", Price = 39.99m, StockQuantity = 20, ImageUrl = "Imgs/p6", CategoryId = 3, BrandId = 3 },
        new Product { ProductId = 4, Name = "HP Zbook Power G9", Price = 49.99m, StockQuantity = 60, ImageUrl = "Imgs/p5", CategoryId = 4, BrandId = 4 },
        new Product { ProductId = 5, Name = "HP Zbook Power G9", Price = 59.99m, StockQuantity = 40, ImageUrl = "Imgs/p4", CategoryId = 5, BrandId = 5 },
        new Product { ProductId = 6, Name = "HP Zbook Power G9", Price = 69.99m, StockQuantity = 25, ImageUrl = "Imgs/p3", CategoryId = 6, BrandId = 6 },
        new Product { ProductId = 7, Name = "HP Zbook Power G9", Price = 79.99m, StockQuantity = 35, ImageUrl = "Imgs/p2", CategoryId = 7, BrandId = 7 },
        new Product { ProductId = 8, Name = "HP Zbook Power G9", Price = 89.99m, StockQuantity = 15, ImageUrl = "Imgs/p3", CategoryId = 8, BrandId = 8 },
        new Product { ProductId = 9, Name = "HP Zbook Power G9", Price = 99.99m, StockQuantity = 10, ImageUrl = "Imgs/p4", CategoryId = 9, BrandId = 9 },
        new Product { ProductId = 10,Name = "HP Zbook Power G9", Price = 109.99m, StockQuantity = 5, ImageUrl = "Imgs/p5", CategoryId = 10, BrandId = 10 },
        new Product { ProductId = 11,Name = "HP Zbook Power G9", Price = 119.99m, StockQuantity = 12, ImageUrl = "Imgs/p10", CategoryId = 11, BrandId = 11 },
        new Product { ProductId = 12,Name = "HP Zbook Power G9", Price = 129.99m, StockQuantity = 18, ImageUrl = "Imgs/p7", CategoryId = 12, BrandId = 12 },
        new Product { ProductId = 13,Name = "HP Zbook Power G9", Price = 139.99m, StockQuantity = 22, ImageUrl = "Imgs/p9", CategoryId = 13, BrandId = 13 },
        new Product { ProductId = 14,Name = "HP Zbook Power G9", Price = 149.99m, StockQuantity = 8, ImageUrl = "Imgs/p8", CategoryId = 14, BrandId = 14 },
        new Product { ProductId = 15,Name = "HP Zbook Power G9", Price = 159.99m, StockQuantity = 6, ImageUrl = "Imgs/p10", CategoryId = 15, BrandId = 15 }
        };

        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.HasKey(x => x.ProductId);

            builder.HasOne(x => x.category)
                   .WithMany(x => x.Products)
                   .HasForeignKey(x => x.CategoryId);


            builder.HasOne(x => x.brand)
                   .WithMany(x => x.Products)
                   .HasForeignKey(x => x.BrandId);

            builder.HasData(products);

        }
    }
}
