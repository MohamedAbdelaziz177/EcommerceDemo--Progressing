using E_Commerce.Models;

namespace E_Commerce.Repositories.IRepositories
{
    public interface IFavoriteRepo : IGeneric<Favorite>
    {

        Task<IEnumerable<Favorite>> GetFavoritesForCustomerAsync(int customerId);
        Task<bool> IsProductInFavoritesAsync(int customerId, int productId);
    }
}
