using E_Commerce.Models;
using E_Commerce.Repositories.IRepositories;
using E_Commerce.Services.IServices;
using E_Commerce.ViewModels;

namespace E_Commerce.Services.MServices
{
    public class CartService : ICartService
    {
        private readonly ICartRepo cartRepo;
        private readonly IProductRepo productRepo;

        public CartService(ICartRepo cartRepo, IProductRepo productRepo)
        {
            this.cartRepo = cartRepo;
            this.productRepo = productRepo;
        }

        public async Task AddToCart(int productId, int userId)
        {
            Cart cart = new Cart();

            cart.ProductId = productId;
            cart.CustomerId = userId;
            cart.quantity = 1;
            cart.UpdatedAt = DateTime.UtcNow;

            await cartRepo.insertAsync(cart);
        }

        public async Task<List<CartVM>> GetAllCarts(int userId)
        {
            List<Cart> carts = await cartRepo.GetAllAsync();
            List<Product> products = await productRepo.GetAllAsync();

            List<CartVM> cartVMs = new List<CartVM>();

            cartVMs =  (from crts in carts
                      join prods in products
                      on crts.ProductId equals prods.ProductId
                      where crts.CustomerId == userId
                      select new CartVM()
                      {
                          CartId = crts.CartId,
                          ProductId = crts.ProductId,
                          customerId = crts.CustomerId,
                          price = prods.Price,
                          ProductName = prods.Name,
                          quantity = crts.quantity,
                          UpdatedAt = crts.UpdatedAt,
 
                      }).ToList();

            return cartVMs;
     
        }

        public async Task<CartVM> GetCartVMbyCartId(int Cartid, int userId)
        {
            var carts = await GetAllCarts(userId);

            return carts.Where(x => x.CartId ==  Cartid).FirstOrDefault();
        }


        public async Task<decimal> getTheTotalCost(int userId) 
        {
           var allCarts =  await GetAllCarts(userId);
           decimal totalCost = 0;

            foreach (var cart in allCarts) 
            {
                totalCost += cart.quantity * cart.price;
            }

            return totalCost;
        }

        public async Task EditQuantity(CartVM cartVM)
        {
            Cart c = new Cart();
            c.CartId = cartVM.CartId;
            c.quantity = cartVM.quantity;
           
            

            await cartRepo.updateAsync(c);
        }

    }
}
