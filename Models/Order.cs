using E_Commerce.ViewModels;
using System.Data.SqlTypes;

namespace E_Commerce.Models
{
    
    public class Order
    {
        public int OrderId { get; set; }

        public int PaymentId { get; set; }
        public int CustomerId { get; set; } // Foreign key to AppUser
        public DateTime OrderDate { get; set; }
        public Decimal TotalAmount { get; set; }
        public OrderStatus Status { get; set; } // Enum for order status
        public ICollection<OrderItem> OrderItems { get; set; }
        public Payment Payment { get; set; }

        public ApplicationUser Customer { get; set; }
    }
}
