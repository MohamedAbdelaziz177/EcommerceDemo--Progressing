using E_Commerce.ViewModels;
using E_Commerce.Models;
using E_Commerce.Repositories.IRepositories;
using E_Commerce.Services.IServices;
using E_Commerce.Repositories.MRepositories;
using System.Drawing.Drawing2D;
using Microsoft.AspNetCore.Mvc;

namespace E_Commerce.Services.MServices
{
    public class ProductService : IProductService
    {
        private readonly IWebHostEnvironment WebHostEnvironment;
        private readonly IProductRepo productRepo;
        private readonly IBrandRepo brandRepo;
        private readonly ICategoryRepo categorytRepo;
        private readonly IBrandService brandService;
        private readonly ICategoryService categoryService;

        public ProductService(IWebHostEnvironment webHostEnvironment,
                              IProductRepo productRepo,
                              IBrandRepo brandRepo,
                              ICategoryRepo categorytRepo,
                              IBrandService brandService,
                              ICategoryService categoryService)
        {
            WebHostEnvironment = webHostEnvironment;
            this.productRepo = productRepo;
            this.brandRepo = brandRepo;
            this.categorytRepo = categorytRepo;
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

        public async Task<ProductDetailsVM> GetProductDetails(int id)
        {

            List<Product> products = await productRepo.GetAllAsync();
            List<Brand> brands = await brandRepo.GetAllAsync();
            List<Category> categories = await categorytRepo.GetAllAsync();


            ProductDetailsVM? prodVM = new ProductDetailsVM();

            prodVM = (

                      from prods in products
                      join cats in categories
                      on prods.CategoryId equals cats.CategoryId
                      join brds in brands
                     on prods.BrandId equals brds.BrandId
                      where prods.ProductId == id
                      select new ProductDetailsVM()
                      {
                          ProductId = prods.ProductId,
                          Name = prods.Name,
                          category = cats.Name,
                          brand = brds.Name,
                          QuantityAvailabe = prods.StockQuantity,
                          ProductImg = prods.ImageUrl + ".jpg",
                          Price = prods.Price,
                          categoryId = prods.CategoryId,
                          brandId = prods.BrandId,

                      }

                      ).FirstOrDefault();

            return prodVM;
            
        }

        public async Task<List<ProductDetailsVM>> GetAllProducts()
        {

            List<Product> products = await productRepo.GetAllAsync();
            List<Brand> brands = await brandRepo.GetAllAsync();
            List<Category> categories = await categorytRepo.GetAllAsync();


            List<ProductDetailsVM> prodsVM = new List<ProductDetailsVM>();

            prodsVM = (

                      from prods in products
                      join cats in categories
                      on prods.CategoryId equals cats.CategoryId
                      join brds in brands
                     on prods.BrandId equals brds.BrandId
                 
                      select new ProductDetailsVM()
                      {
                          ProductId = prods.ProductId,
                          Name = prods.Name,
                          category = cats.Name,
                          brand = brds.Name,
                          QuantityAvailabe = prods.StockQuantity,
                          ProductImg = prods.ImageUrl + ".jpg",
                          Price = prods.Price,
                          categoryId = prods.CategoryId,
                          brandId = prods.BrandId,

                      }

                      ).ToList();

            return prodsVM;

        }


        public async Task<List<ProductDetailsVM>> GetProductsByCategoryId(int id)
        {
            var products = await GetAllProducts();
           

            var filteredProducts = products.Where(x => x.categoryId == id).ToList();

            return filteredProducts;

        }


        public async Task<List<ProductDetailsVM>> GetProductsByBrandId(int id)
        {
            var products = await GetAllProducts();

            var filteredProducts = products.Where(x => x.brandId == id).ToList();

            return filteredProducts;

        }

    }
}
