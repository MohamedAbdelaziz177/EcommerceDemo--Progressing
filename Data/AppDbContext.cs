using E_Commerce.Models;
using E_Commerce.ViewModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace E_Commerce.Data
{
	public class AppDbContext : IdentityDbContext<ApplicationUser, ApplicationRole, int>
	{

        //public DbContextOptions<AppDbContext> Options { get; }
        public AppDbContext(DbContextOptions<AppDbContext> options)
		   : base(options)
		{
			//Options = options;
		}

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);


            // Configure the primary key for IdentityUserLogin<int>

           

            // Configure the primary key for IdentityUserLogin<int>
            builder.Entity<IdentityUserLogin<int>>()
                .HasKey(x => new { x.LoginProvider, x.ProviderKey, x.UserId });

            // Optionally, configure other Identity entities (like IdentityUserRole, IdentityUserClaim)
            builder.Entity<IdentityUserRole<int>>()
                .HasKey(x => new { x.UserId, x.RoleId });

            builder.Entity<IdentityUserClaim<int>>()
                .HasKey(x => x.Id);


           
            new CartFluentAPIconfig().Configure(builder.Entity<Cart>());

            new FavoriteFluentAPIconfig().Configure(builder.Entity<Favorite>());

            new OrderFluentAPIconfig().Configure(builder.Entity<Order>());

            new OrderItemFluentAPIconfig().Configure(builder.Entity<OrderItem>());

            new ProductFluentAPIconfig().Configure(builder.Entity<Product>());

            new PaymentFluentAPIconfig().Configure(builder.Entity<Payment>());

            new BrandFluentAPIconfig().Configure(builder.Entity<Brand>());

            new CategoryFluentAPIconfig().Configure(builder.Entity<Category>());





        }

        public DbSet<Category> Categories { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Favorite> Favorites { get; set; }
        public DbSet<Cart> Carts { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderItem> OrderItems { get; set; }
        public DbSet<Payment> Payments { get; set; }
        public DbSet<Brand> Brands { get; set; }


    }
}
