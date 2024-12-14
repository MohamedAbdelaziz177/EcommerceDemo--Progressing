using E_Commerce.Models;

namespace E_Commerce.Repositories.IRepositories
{
    public interface IOrderItemRepo : IGeneric<OrderItem>
    {
        Task<IEnumerable<OrderItem>> GetOrderItemsByOrderIdAsync(int orderId);
    }
}
