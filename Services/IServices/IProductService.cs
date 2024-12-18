using E_Commerce.Models;
using E_Commerce.ViewModels;

namespace E_Commerce.Services.IServices
{
    public interface IProductService
    {
        public Task SaveProduct(AddProductVM model);
        public Task DeleteProductAsync(int id);

        public Task SaveUpdatedProduct(EditProductVM model);

        public Task<Product> GetProductById(int id);

        public Task<EditProductVM> updateProduct(int id);

        public Task<ProductDetailsVM> GetProductDetails(int id);

        public Task<List<ProductDetailsVM>> GetAllProducts();

        public  Task<List<ProductDetailsVM>> GetProductsByCategoryId(int id);

        public  Task<List<ProductDetailsVM>> GetProductsByBrandId(int id);


    }
}
