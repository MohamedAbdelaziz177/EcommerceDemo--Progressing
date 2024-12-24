using E_Commerce.Repositories.IRepositories;
using E_Commerce.Services.IServices;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Identity;
using System.Security.Claims;
using E_Commerce.Models;
using E_Commerce.Repositories.MRepositories;
using System.ComponentModel;

namespace E_Commerce.Services.MServices
{
    public class FavService : IFavService
    {
        private readonly IFavoriteRepo favoriteRepo;
        private readonly IProductRepo productRepo;

        public FavService(IFavoriteRepo favoriteRepo, IProductRepo productRepo)
        {
            this.favoriteRepo = favoriteRepo;
            this.productRepo = productRepo;
        }

        public async Task RemoveFavByProductId(int productId, int userId)
        {
            await favoriteRepo.DeleteFavByCustAndProd(userId, productId);
        }

        public async Task AddProductToFavorites(int productId, int userId)
        {
            Product prod = await productRepo.GetByIdAsync(productId);

            Favorite fav = new Favorite();

            fav.ProductId = productId;

            fav.CustomerId = userId;

            fav.Product = prod;

            await favoriteRepo.insertAsync(fav);
        }


        public async Task<List<Product>> GetAllFavedProducts(int userId)
        {
                var FavedProducts =
                    await favoriteRepo.GetFavoritesForCustomerAsync(userId);

                List<Product> products = new List<Product>();

                foreach (var fav in FavedProducts)
                {
                    var product = await productRepo.GetByIdAsync(fav.ProductId);
                    products.Add(product);
                }

                return products;
        }

    }
}
