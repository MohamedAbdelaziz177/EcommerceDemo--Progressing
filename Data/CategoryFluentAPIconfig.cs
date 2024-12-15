using E_Commerce.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace E_Commerce.Data
{
    public class CategoryFluentAPIconfig : IEntityTypeConfiguration<Category>
    {
        List<Category> categories = new List<Category>(){

            new Category { CategoryId = 1, Name = "Electronics", Description = "Devices, gadgets, and technology products" },
            new Category { CategoryId = 2, Name = "Fashion", Description = "Clothing, footwear, and accessories" },
            new Category { CategoryId = 3, Name = "Home & Kitchen", Description = "Furniture, appliances, and kitchenware" },
            new Category { CategoryId = 4, Name = "Sports & Outdoors", Description = "Sports equipment and outdoor gear" },
            new Category { CategoryId = 5, Name = "Health & Beauty", Description = "Skincare, haircare, and wellness products" },
            new Category { CategoryId = 6, Name = "Books", Description = "Fiction, non-fiction, and educational books" },
            new Category { CategoryId = 7, Name = "Toys & Games", Description = "Toys, board games, and puzzles" },
            new Category { CategoryId = 8, Name = "Automotive", Description = "Car accessories and maintenance products" },
            new Category { CategoryId = 9, Name = "Groceries", Description = "Food, beverages, and household supplies" },
            new Category { CategoryId = 10, Name = "Jewelry & Watches", Description = "Rings, necklaces, and wristwatches" },
            new Category { CategoryId = 11, Name = "Baby Products", Description = "Items for babies and toddlers" },
            new Category { CategoryId = 12, Name = "Pet Supplies", Description = "Products for pet care and grooming" },
            new Category { CategoryId = 13, Name = "Office Supplies", Description = "Stationery and office equipment" },
            new Category { CategoryId = 14, Name = "Gaming", Description = "Video games, consoles, and accessories" },
            new Category { CategoryId = 15, Name = "Music Instruments", Description = "Guitars, keyboards, and other instruments" },
            new Category { CategoryId = 16, Name = "Health & Fitness", Description = "Gym equipment and fitness gear" },
            new Category { CategoryId = 17, Name = "Arts & Crafts", Description = "Art supplies and crafting materials" },
            new Category { CategoryId = 18, Name = "Travel", Description = "Luggage and travel accessories" },
            new Category { CategoryId = 19, Name = "Garden & Tools", Description = "Gardening tools and outdoor equipment" },
            new Category { CategoryId = 20, Name = "Collectibles", Description = "Memorabilia and rare items for collectors" }
            };

        public void Configure(EntityTypeBuilder<Category> builder)
        {
            builder.HasData(categories);
        }
    }
}
