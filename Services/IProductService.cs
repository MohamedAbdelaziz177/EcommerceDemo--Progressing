using E_Commerce.ViewModels;

namespace E_Commerce.Services
{
    public interface IProductService
    {
        public Task SaveProduct(AddProductVM model);

    }
}
