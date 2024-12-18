using E_Commerce.Data;
using E_Commerce.Models;
using E_Commerce.Services.IServices;
using E_Commerce.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace E_Commerce.Controllers
{
    public class ProductController : Controller
    {

        private readonly ICategoryService categoryService;
        private readonly IBrandService brandService;
        private readonly IProductService productService;

        public ProductController(ICategoryService categoryService, IBrandService brandService, IProductService productService)
        {
            this.categoryService = categoryService;
            this.brandService = brandService;
            this.productService = productService;
        }


        
        public async Task<IActionResult> GetAllProducts()
        {
            List<ProductDetailsVM> products = await productService.GetAllProducts();
            return View(products);
        }

        public async Task<IActionResult> GetProductDetails(int id) 
        {
            ProductDetailsVM prod = await productService.GetProductDetails(id);
            return View(prod);
        }



        [Authorize(Roles = "admin")]
        [HttpGet]
        public async Task<IActionResult> AddNewProduct()
        {
            
            AddProductVM AddProductVM = new AddProductVM()
            {
                Categories = await categoryService.GetAllCategories(),
                Brands = await brandService.GetAllBrands()
            };


            return View(AddProductVM);
        }

        [Authorize(Roles = "admin")]
        [HttpPost]
        public async Task<IActionResult> SaveNewProduct(AddProductVM product) 
        {
            if (!ModelState.IsValid)
            {
                product.Categories = await categoryService.GetAllCategories();
                product.Brands = await brandService.GetAllBrands(); 

                return View("AddNewProduct", product);
            }

            await productService.SaveProduct(product);

            return RedirectToAction("GetAllProducts");
        }

        [Authorize(Roles = "admin")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteProduct(int ProductId) 
        {           
            await productService.DeleteProductAsync(ProductId);

            return RedirectToAction("GetAllProducts");
        }

        [HttpGet]
        [Authorize(Roles = "admin")]

        public async Task<IActionResult> EditProduct(int id) 
        {

            EditProductVM EditProductVM = await productService.updateProduct(id);

            return View(EditProductVM);

        }

        [HttpPost]
        [Authorize(Roles = "admin")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> SaveEdit(EditProductVM product)
        {

            if (!ModelState.IsValid)
            {
                product.Categories = await categoryService.GetAllCategories();
                product.Brands = await brandService.GetAllBrands();

                return View("EditProduct", product);
            }


            // Update Logic

            await productService.SaveUpdatedProduct(product);

            return RedirectToAction("GetAllProducts");

        }

        public async Task<IActionResult> GetProductsByCategory(int id)
        {
            var productsFiltered = await productService.GetProductsByCategoryId(id);
            return View("GetAllProducts" , productsFiltered);

        }

        public async Task<IActionResult> GetProductsByBrand(int id)
        {
            var productsFiltered = await productService.GetProductsByBrandId(id);
            return View("GetAllProducts", productsFiltered);

        }
    }
}
