using System.ComponentModel.DataAnnotations;

namespace E_Commerce.Models
{
    public class Brand
    {
        public int BrandId { get; set; }

        [Display(Name = "Brand: ")]
        public string Name { get; set; }

        public ICollection<Product> Products { get; set; }

    }
}
