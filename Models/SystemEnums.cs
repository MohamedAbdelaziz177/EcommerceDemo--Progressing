namespace E_Commerce.Models
{
    public enum OrderStatus
    {
        Pending,
        Processing,
        Shipped,
        Delivered,
        Cancelled
    }

    public enum PaymentMethod
    {
        CreditCard,
        PayPal,
        BankTransfer
    }
    public enum PaymentStatus
    {
        Pending,
        Completed,
        Failed
    }
}
