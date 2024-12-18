using E_Commerce.ViewModels;
using E_Commerce.Models;
using E_Commerce.Repositories.IRepositories;
using E_Commerce.Services.IServices;

namespace E_Commerce.Services.MServices
{
    public class ProductService : IProductService
    {
        private readonly IWebHostEnvironment WebHostEnvironment;
        private readonly IProductRepo productRepo;
        private readonly IBrandService brandService;
        private readonly ICategoryService categoryService;

        public ProductService(IWebHostEnvironment webHostEnvironment,
                              IProductRepo productRepo, IBrandService brandService,
                              ICategoryService categoryService)
        {
            WebHostEnvironment = webHostEnvironment;
            this.productRepo = productRepo;
            this.brandService = brandService;
            this.categoryService = categoryService;
        }



        public async Task<Product> GetProductById(int id)
        {
            return await productRepo.GetByIdAsync(id);
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


        public async Task<EditProductVM> updateProduct(int id)
        {
            Product product = await productRepo.GetByIdAsync(id);

            EditProductVM EditProductVM = new EditProductVM()
            {
                Categories = await categoryService.GetAllCategories(),
                Brands = await brandService.GetAllBrands(),
                ProductID = id,
                Price = product.Price,
                BrandId = product.BrandId,
                CategoryId = product.CategoryId,
                StockQuantity = product.StockQuantity,
                Name = product.Name

            };

            return EditProductVM;
        }


        public async Task SaveUpdatedProduct(EditProductVM model)
        {

            var coverName = $"{Guid.NewGuid().ToString()}{Path.GetExtension(model.Image.FileName)}";
            var imgPath = $"{WebHostEnvironment.WebRootPath}/Imgs/Product";

            var fullPath = Path.Combine(imgPath, coverName);

            
            using (var fileStream = new FileStream(fullPath, FileMode.Create))
            {
                await model.Image.CopyToAsync(fileStream);
            }

            


            var Product = new Product();

            Product.ProductId = model.ProductID;
            Product.Name = model.Name;
            Product.BrandId = model.BrandId;
            Product.CategoryId = model.CategoryId;
            Product.Price = model.Price;
            Product.StockQuantity = model.StockQuantity;
            Product.ImageUrl = fullPath;

            await productRepo.updateAsync(Product);

        }



        public async Task DeleteProductAsync(int id)
        {
            await productRepo.deleteAsync(id);
        }
    }
}
