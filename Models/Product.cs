namespace E_Commerce.Models
{
    public class Product
    {
        public int ProductId { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public int StockQuantity { get; set; }
        public string ImageUrl { get; set; }
        public int CategoryId { get; set; }

        public int BrandId { get; set; }


        public Category category { get; set; }

        public Brand brand { get; set; }

       // public ICollection<OrderItem> OrderItems { get; set; } // Navigation property

    }
}
