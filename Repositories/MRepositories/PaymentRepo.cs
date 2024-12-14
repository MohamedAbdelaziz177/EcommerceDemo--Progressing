
using E_Commerce.Data;
using E_Commerce.Models;
using E_Commerce.Repositories.IRepositories;
using Microsoft.EntityFrameworkCore;

namespace E_Commerce.Repositories.MRepositories
{
    public class PaymentRepo : IPaymentRepo
    {

        private readonly AppDbContext con;

        public PaymentRepo(AppDbContext con)
        {
            this.con = con;
        }
        public async Task deleteAsync(int id)
        {
            var Payment = await con.Payments.FindAsync(id);

            if (Payment != null)
                con.Payments.Remove(Payment);

            await con.SaveChangesAsync();
        }

        public async Task<List<Payment>> GetAllAsync()
        {
            var lstOfPayments = await con.Payments.ToListAsync();

            return lstOfPayments;
        }

        public async Task<Payment> GetByIdAsync(int id)
        {
            var Payment = await con.Payments.FindAsync(id);

            // await con.SaveChangesAsync();

            return Payment;
        }

        public async Task insertAsync(Payment entity)
        {
            await con.Payments.AddAsync(entity);

            await con.SaveChangesAsync();
        }

        public async Task updateAsync(Payment entity)
        {
            con.Payments.Update(entity);

            await con.SaveChangesAsync();
        }

        //-----------------------------------------------------
        public async Task<Payment> GetPaymentByOrderIdAsync(int orderId)
        {
            var payment =  con.Payments.Where(x => x.OrderId == orderId).FirstOrDefault();
            return payment;
        }
    }
}
