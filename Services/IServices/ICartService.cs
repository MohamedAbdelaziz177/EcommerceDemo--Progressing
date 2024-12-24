using E_Commerce.ViewModels;

namespace E_Commerce.Services.IServices
{
    public interface ICartService
    {
        public Task AddToCart(int productId, int userId);

        public  Task<List<CartVM>> GetAllCarts(int userId);
        public Task<decimal> getTheTotalCost(int userId);

        public Task EditQuantity(CartVM cartVM);

        public  Task<CartVM> GetCartVMbyCartId(int Cartid, int userId);

    }
}
