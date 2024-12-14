using E_Commerce.Models;
using Microsoft.AspNetCore.Identity;

namespace E_Commerce.ViewModels
{
	public class ApplicationUser : IdentityUser<int>
	{
        public string Address { get; set; }

        public ICollection<Favorite> Favorites { get; set; }
        public ICollection<Cart> CartItems { get; set; }
        public ICollection<Order> Orders { get; set; }
    }
}
