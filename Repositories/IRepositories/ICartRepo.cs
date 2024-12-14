using E_Commerce.Models;

namespace E_Commerce.Repositories.IRepositories
{
    public interface ICartRepo : IGeneric<Cart>
    {
        Task<IEnumerable<Cart>> GetCartForCustomerAsync(int customerId);
        Task ClearCartAsync(int customerId);
        

    }
}
