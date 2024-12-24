using Microsoft.IdentityModel.Protocols.OpenIdConnect;

namespace E_Commerce.ViewModels
{
    public class CartVM
    {
        public int CartId { get; set; }
        public int ProductId { get; set; }

        public string ProductName { get; set; }

        public int customerId { get; set; }

        public decimal price { get; set; }

        public int quantity { get; set; }

        public decimal TotalPrice {  get; set; }

        public DateTime UpdatedAt { get; set; }
    }
}
