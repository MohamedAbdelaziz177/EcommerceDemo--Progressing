using E_Commerce.ViewModels;
using System.ComponentModel.DataAnnotations.Schema;

namespace E_Commerce.Models
{
    public class Cart
    {
        public int CartId { get; set; }

        [ForeignKey("Customer")]
        public int CustomerId { get; set; }

        [ForeignKey("Product")]
        public int ProductId { get; set; }

        public int quantity { get; set; }

        public DateTime UpdatedAt { get; set; }

        public Product Product { get; set; }
        public ApplicationUser Customer { get; set; }
    }
}
