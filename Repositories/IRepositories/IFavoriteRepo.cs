using E_Commerce.Models;

namespace E_Commerce.Repositories.IRepositories
{
    public interface IFavoriteRepo : IGeneric<Favorite>
    {

        Task<IEnumerable<Favorite>> GetFavoritesForCustomerAsync(int customerId);
     //   Task<List<Product>> GetFavoritesForCustomerAsync(string? userId);
        Task<bool> IsProductInFavoritesAsync(int customerId, int productId);

        public Task<Favorite> GetFavByCustAndProd(int customerId, int productId);

        public  Task DeleteFavByCustAndProd(int customerId, int productId);
    }
}
