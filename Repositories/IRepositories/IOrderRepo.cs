using E_Commerce.Models;

namespace E_Commerce.Repositories.IRepositories
{
    public interface IOrderRepo : IGeneric<Order>
    {
        Task<IEnumerable<Order>> GetOrdersByCustomerAsync(int customerId);

        // Task<Order> GetOrderWithDetailsAsync(int orderId);
    }
}
