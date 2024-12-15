using E_Commerce.ViewModels;
using E_Commerce.Models;
using E_Commerce.Repositories.IRepositories;

namespace E_Commerce.Services
{
    public class ProductService : IProductService
    {
        private readonly IWebHostEnvironment WebHostEnvironment;
        private readonly IProductRepo productRepo;

        public ProductService(IWebHostEnvironment webHostEnvironment, IProductRepo productRepo)
        {
            WebHostEnvironment = webHostEnvironment;
            this.productRepo = productRepo;
        }


       

        public async Task SaveProduct(AddProductVM model)
        {

            var coverName = $"{Guid.NewGuid().ToString()}{Path.GetExtension(model.Image.FileName)}";
            var imgPath = $"{WebHostEnvironment.WebRootPath}/Imgs/Product";

            var fullPath = Path.Combine(imgPath, coverName);

            using (var fileStream = new FileStream(fullPath, FileMode.Create))
            {
                await model.Image.CopyToAsync(fileStream);
            }


            var Product = new Product();
            Product.Name = model.Name;
            Product.BrandId = model.BrandId;
            Product.CategoryId = model.CategoryId;
            Product.Price = model.Price;
            Product.StockQuantity = model.StockQuantity;
            Product.ImageUrl = fullPath;

            await productRepo.insertAsync(Product);
            
        }
     
    }
}
