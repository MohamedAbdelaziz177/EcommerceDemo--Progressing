
using E_Commerce.Data;
using E_Commerce.Models;
using E_Commerce.Repositories.IRepositories;
using Microsoft.EntityFrameworkCore;

namespace E_Commerce.Repositories.MRepositories
{
    public class CartRepo : ICartRepo
    {
        private readonly AppDbContext con;

        public CartRepo(AppDbContext con)
        {
            this.con = con;
        }
        public async Task deleteAsync(int id)
        {
            var Cart = await con.Carts.FindAsync(id);

            if (Cart != null)
                con.Carts.Remove(Cart);

            await con.SaveChangesAsync();

        }

        public async Task<List<Cart>> GetAllAsync()
        {
            var lstOfCarts = await con.Carts.ToListAsync();

            return lstOfCarts;
        }

        public async Task<Cart> GetByIdAsync(int id)
        {
            var Cart = await con.Carts.FindAsync(id);

            // await con.SaveChangesAsync();

            return Cart;
        }

        public async Task insertAsync(Cart entity)
        {
            await con.Carts.AddAsync(entity);

            await con.SaveChangesAsync();

        }

        public async Task updateAsync(Cart entity)
        {
            var c = con.Carts.Find(entity.CartId);
            c.quantity = entity.quantity;

            await con.SaveChangesAsync();
        }


        //-----------------------------------------------------
        public async Task ClearCartAsync(int customerId)
        {
            var CustomerCart = await con.Carts.Where(x => x.CustomerId == customerId).ToListAsync();

            con.Carts.RemoveRange(CustomerCart);
        }

        public async Task<IEnumerable<Cart>> GetCartForCustomerAsync(int customerId)
        {
            var CustomerCart = await con.Carts.Where(x => x.CustomerId == customerId).ToListAsync();

            return CustomerCart;
        }

       
    }
}
