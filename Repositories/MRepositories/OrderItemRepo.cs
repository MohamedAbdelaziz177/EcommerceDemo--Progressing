
using E_Commerce.Data;
using E_Commerce.Models;
using E_Commerce.Repositories.IRepositories;
using Microsoft.EntityFrameworkCore;

namespace E_Commerce.Repositories.MRepositories
{
    public class OrderItemRepo : IOrderItemRepo
    {
        private readonly AppDbContext con;

        public OrderItemRepo(AppDbContext con)
        {
            this.con = con;
        }

        public async Task deleteAsync(int id)
        {
            var item = await con.OrderItems.FindAsync(id);

            if (item != null)
                con.OrderItems.Remove(item);

            await con.SaveChangesAsync();
        }

        public async Task<List<OrderItem>> GetAllAsync()
        {
            var orderItems = await con.OrderItems.ToListAsync();

            return orderItems;
        }

        public async Task<OrderItem> GetByIdAsync(int id)
        {
            var OrderItem = await con.OrderItems.FindAsync(id);

            // await con.SaveChangesAsync();

            return OrderItem;
        }

       

        public async Task insertAsync(OrderItem entity)
        {
            await con.OrderItems.AddAsync(entity);

            await con.SaveChangesAsync();
        }

        public async Task updateAsync(OrderItem entity)
        {
            

            con.OrderItems.Update(entity);

            await con.SaveChangesAsync();
        }

        //-----------------------------------------------------
        public async Task<IEnumerable<OrderItem>> GetOrderItemsByOrderIdAsync(int orderId)
        {
            var itemlLst = await con.OrderItems.Where(x => x.OrderId == orderId).ToListAsync();

            return itemlLst;
        }
    }
}
