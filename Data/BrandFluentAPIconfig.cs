using E_Commerce.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace E_Commerce.Data
{
    public class BrandFluentAPIconfig : IEntityTypeConfiguration<Brand>
    {

        List<Brand> brands = new List<Brand>
        {
            new Brand { BrandId = 1, Name = "Nike" },
            new Brand { BrandId = 2, Name = "Adidas" },
            new Brand { BrandId = 3, Name = "Puma" },
            new Brand { BrandId = 4, Name = "Reebok" },
            new Brand { BrandId = 5, Name = "Under Armour" },
            new Brand { BrandId = 6, Name = "Asics" },
            new Brand { BrandId = 7, Name = "New Balance" },
            new Brand { BrandId = 8, Name = "Skechers" },
            new Brand { BrandId = 9, Name = "Converse" },
            new Brand { BrandId = 10, Name = "Vans" },
            new Brand { BrandId = 11, Name = "Fila" },
            new Brand { BrandId = 12, Name = "Columbia" },
            new Brand { BrandId = 13, Name = "The North Face" },
            new Brand { BrandId = 14, Name = "Timberland" },
            new Brand { BrandId = 15, Name = "Hoka One One" },
            new Brand { BrandId = 16, Name = "Brooks" },
            new Brand { BrandId = 17, Name = "Champion" },
            new Brand { BrandId = 18, Name = "Lululemon" },
            new Brand { BrandId = 19, Name = "Arc'teryx" },
            new Brand { BrandId = 20, Name = "Patagonia" }
        };

        public void Configure(EntityTypeBuilder<Brand> builder)
        {
            builder.HasData(brands);
        }
    }
}
