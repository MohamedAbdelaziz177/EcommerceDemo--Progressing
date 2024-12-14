using System.Data.SqlTypes;

namespace E_Commerce.Models
{
    
    public class Payment
    {
        public int PaymentId { get; set; }
        public int OrderId { get; set; }
        public PaymentMethod Method { get; set; } // Enum for payment method (e.g., CreditCard, PayPal)
        public PaymentStatus Status { get; set; } // Enum for payment status (e.g., Pending, Completed)
        public DateTime PaymentDate { get; set; }
        public decimal Amount { get; set; }

        public Order Order { get; set; }
    }
}
