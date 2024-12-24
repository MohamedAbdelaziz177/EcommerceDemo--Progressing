using E_Commerce.Models;
using E_Commerce.Repositories.IRepositories;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace E_Commerce.Services.IServices
{
    public interface IFavService
    {

        public Task RemoveFavByProductId(int productId, int userId);

        public Task AddProductToFavorites(int productId, int userId);

        public Task<List<Product>> GetAllFavedProducts(int userId);
    }
}
