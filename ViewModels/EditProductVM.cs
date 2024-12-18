using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace E_Commerce.ViewModels
{
    public class EditProductVM
    {

        public int ProductID { get; set; }

        [MaxLength(100)]
        [Required(ErrorMessage = "REQUIRED !!")]

        public string Name { get; set; }


        [Required(ErrorMessage = "REQUIRED !!")]
        [Display(Name = "Category: ")]

        public int CategoryId { get; set; }
        // public string CategoryName { get; set; }

        public IEnumerable<SelectListItem> Categories { get; set; } = Enumerable.Empty<SelectListItem>();

        [Display(Name = "Brand: ")]
        [Required(ErrorMessage = "REQUIRED !!")]

        public int BrandId { get; set; }
        /// <summary>
        // public string BrandName { get; set; }

        public IEnumerable<SelectListItem> Brands { get; set; } = Enumerable.Empty<SelectListItem>();

        [Required(ErrorMessage = "REQUIRED !!")]
        public decimal Price { get; set; }

        [Display(Name = "Quantity Available: ")]
        [Range(0, 100)]
        public int StockQuantity { get; set; }

        [Required(ErrorMessage = "REQUIRED !!")]
        public IFormFile Image { get; set; }

        [Required(ErrorMessage = "REQUIRED !!")]

        [MaxLength(1000)]
        public string Description { get; set; } = "Lorem ipsum dolor sit amet, consectetur adipiscing elit,\n sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. Duis aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur. Excepteur sint occaecat cupidatat non proident, sunt in culpa qui officia deserunt mollit anim id est laborum.";



    }
}
