using E_Commerce.Data;
using E_Commerce.ViewModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;


namespace E_Commerce
{
	public class Program
	{
		public static void Main(string[] args)
		{
			var builder = WebApplication.CreateBuilder(args);

			// Add services to the container.
			builder.Services.AddControllersWithViews();

			//builder.Services.AddDbContext<IdentityDbContext>
			//	(options => options.
				//UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

			builder.Services.AddDbContext<AppDbContext>
				(options => options
				.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));


			// Registering the AppUser Manager & RoleManager 
			builder.Services.AddIdentity<ApplicationUser, ApplicationRole>
		       (
				/*Here You can change the policy of the passowrd --> opt => opt.password . ## = '1 / 0 '*/
				options =>
				{
					options.Password.RequireUppercase = false;
					options.Password.RequireLowercase = false;
				}

				)

				.AddEntityFrameworkStores<AppDbContext>(); // Registering The Stores to the manager
			

			var app = builder.Build();

			// Configure the HTTP request pipeline.
			if (!app.Environment.IsDevelopment())
			{
				app.UseExceptionHandler("/Home/Error");
			}


			app.UseStaticFiles();

			app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

			app.MapControllerRoute(
				name: "default",
				pattern: "{controller=Home}/{action=Index}/{id?}");

			app.Run();
		}
	}
}
