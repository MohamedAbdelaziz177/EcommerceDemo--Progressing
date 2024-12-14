using Microsoft.VisualStudio.Web.CodeGenerators.Mvc.Templates.General;
using E_Commerce.ViewModels;
using System.ComponentModel.DataAnnotations.Schema;

namespace E_Commerce.Models
{
    public class Favorite
    {
        public int FavId { get; set; }

        [ForeignKey("ApplicationUser")]

        public int CustomerId { get; set; }

        [ForeignKey("Product")]
        public int ProductId { get; set; }

        public Product Product { get; set; }
        public ApplicationUser Customer { get; set; }
    }
}
