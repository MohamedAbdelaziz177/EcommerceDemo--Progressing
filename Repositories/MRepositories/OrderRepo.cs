
using E_Commerce.Data;
using E_Commerce.Models;
using E_Commerce.Repositories.IRepositories;
using Microsoft.EntityFrameworkCore;
using static NuGet.Packaging.PackagingConstants;

namespace E_Commerce.Repositories.MRepositories
{
    public class OrderRepo : IOrderRepo
    {
        private readonly AppDbContext con;

        public OrderRepo(AppDbContext con)
        {
            this.con = con;
        }
           
        public async Task deleteAsync(int id)
        {
            var Order = await con.Orders.FindAsync(id);

            if (Order != null)
                con.Orders.Remove(Order);

            await con.SaveChangesAsync();
        }

        public async Task<List<Order>> GetAllAsync()
        {
            var lstOfOrders = await con.Orders.ToListAsync();

            return lstOfOrders;
        }

        public async Task<Order> GetByIdAsync(int id)
        {
            var Order = await con.Orders.FindAsync(id);

            // await con.SaveChangesAsync();

            return Order;
        }

        public async Task insertAsync(Order entity)
        {
            await con.Orders.AddAsync(entity);

            await con.SaveChangesAsync();
        }

        public async Task updateAsync(Order entity)
        {
            con.Orders.Update(entity);

            await con.SaveChangesAsync();
        }


        //-----------------------------------------------------
        public async Task<IEnumerable<Order>> GetOrdersByCustomerAsync(int customerId)
        {
            var orders = await con.Orders.Where(x => x.CustomerId == customerId).ToListAsync();

            return orders;

        }

       
    }
}
