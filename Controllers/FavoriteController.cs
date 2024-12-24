using E_Commerce.Models;
using E_Commerce.Repositories.IRepositories;
using E_Commerce.Services.IServices;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace E_Commerce.Controllers
{
    public class FavoriteController : Controller
    {
        private readonly IFavoriteRepo favoriteRepo;
        private readonly IProductRepo productRepo;
        private readonly IFavService favService;

        public FavoriteController(IFavoriteRepo favoriteRepo,
                                  IProductRepo productRepo, IFavService favService
                                  ) 
        {
            this.favoriteRepo = favoriteRepo;
            this.productRepo = productRepo;
            this.favService = favService;
        }
        public IActionResult Index()
        {
            return View();
        }

        public async Task<IActionResult> GetAllFaved()
        {
            if (User.Identity.IsAuthenticated)
            {
                List<Product> Products = new List<Product>();

                string UserId = User.FindFirstValue(ClaimTypes.NameIdentifier);

                Products = await favService.GetAllFavedProducts(int.Parse(UserId));
    

                return View(Products);
            }

            else return View("Register");
        }

        public async Task<IActionResult> AddToFavorites(int id) 
        {
            string UserId = User.FindFirstValue(ClaimTypes.NameIdentifier);

            await favService.AddProductToFavorites(id, int.Parse(UserId));


           return View("GetAllFavs");
            
        }


        // Removes by FavId from the fav page itself
        public async Task<IActionResult> RemoveFromFavorites(int id)
        {
           await favoriteRepo.deleteAsync(id);
            return View("GetAllFavs");
        }


        // Removes by ProductId from the product page
        public async Task<IActionResult> RemoveProductFromFavorites(int id)
        {
            string UserId = User.FindFirstValue(ClaimTypes.NameIdentifier);

            await favService.RemoveFavByProductId(id, int.Parse(UserId));

            return View("GetAllProducts");
            
        }
    }
}
