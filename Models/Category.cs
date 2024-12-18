using System.ComponentModel.DataAnnotations;

namespace E_Commerce.Models
{
    public class Category
    {
        public int CategoryId { get; set; }

        [Required]
        [Display(Name = "Category: ")]
        public string Name { get; set; }

        [Required]
        [MinLength(15)]
        [MaxLength(1000)]

        [Display(Name = "Description: ")]
        public string Description { get; set; }
        public ICollection<Product> Products { get; set; }
    }
}
