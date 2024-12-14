using E_Commerce.Models;

namespace E_Commerce.Repositories.IRepositories
{
    public interface IPaymentRepo : IGeneric<Payment>
    {
        Task<Payment> GetPaymentByOrderIdAsync(int orderId);
    }
}
