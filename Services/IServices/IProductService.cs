﻿using E_Commerce.Models;
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

    }
}