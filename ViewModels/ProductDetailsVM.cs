using System.Data.SqlTypes;

namespace E_Commerce.ViewModels
{
    public class ProductDetailsVM
    {

        public int ProductId { get; set; }

        public int categoryId { get; set; }

        public int brandId { get; set; }
        public string Name { get; set; }

        public decimal Price { get; set; }

        public string Description { get; set; } = "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. Duis aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur. Excepteur sint occaecat cupidatat non proident, sunt in culpa qui officia deserunt mollit anim id est laborum.";

        public string category { get; set; }

        public string brand { get; set; }

        public int QuantityAvailabe { get; set; }

        public string ProductImg {  get; set; }
        
       
    }
}
