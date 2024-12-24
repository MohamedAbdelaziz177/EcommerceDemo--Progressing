using E_Commerce.Models;
using E_Commerce.Repositories.IRepositories;
using E_Commerce.Repositories.MRepositories;
using E_Commerce.Services.IServices;
using E_Commerce.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace E_Commerce.Controllers
{
    public class CartController : Controller
    {
        private readonly ICartRepo cartRepo;
        private readonly ICartService cartService;
        private int userID;

        public CartController(ICartRepo cartRepo, ICartService cartService)
        {
            this.cartRepo = cartRepo;
            this.cartService = cartService;
            
        }


        public async Task<IActionResult> AddToCart(int id)
        {
              if(User.Identity.IsAuthenticated)
              {
                userID = int.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier));
                await cartService.AddToCart(id, userID);

                return RedirectToAction(nameof(GetAllCarts));
              }

              else
              {
                  return RedirectToAction("Register", "Account");
              }


        }

        public async Task<IActionResult> RemoveFromCart(int id)
        {
            await cartRepo.deleteAsync(id);
            return RedirectToAction("GetAllCarts");
        }
        

        public async Task<IActionResult> GetAllCarts()
        {
            if (User.Identity.IsAuthenticated)
            {
                userID = int.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier));
                var cartsVM = await cartService.GetAllCarts(userID);

                decimal totalCost = await cartService.getTheTotalCost(userID);

                ViewData["totalCost"] = totalCost;

                return View(cartsVM);
            }

           

            return RedirectToAction("Register", "Account");
        }


        [HttpGet]
        public async Task<IActionResult> EditCart(int id)
        {
            if (User.Identity.IsAuthenticated)
            {
                userID = int.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier));

                CartVM c = await cartService.GetCartVMbyCartId(id, userID);

                return View(c);
            }

            return RedirectToAction("Register", "Account");


        }

        [HttpPost]
        [AutoValidateAntiforgeryToken]
        public async Task<IActionResult> SaveEdit(CartVM cart)
        {
             await cartService.EditQuantity(cart);

           

            return RedirectToAction("GetAllCarts");
        }


    }
}
