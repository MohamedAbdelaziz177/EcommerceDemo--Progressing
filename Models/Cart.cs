using E_Commerce.ViewModels;
using System.ComponentModel.DataAnnotations.Schema;

namespace E_Commerce.Models
{
    [Table("Carts")]
    public class Cart
    {
        public int CartId { get; set; }

        [ForeignKey("ApplicationUser")]
        public int CustomerId { get; set; }

        [ForeignKey("Product")]
        public int ProductId { get; set; }

        public int quantity { get; set; }

        public DateTime UpdatedAt { get; set; }

       // public decimal Total { get; set; }

        public Product Product { get; set; }
        public ApplicationUser Customer { get; set; }
    }
}
