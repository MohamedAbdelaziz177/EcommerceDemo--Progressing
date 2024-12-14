
using E_Commerce.Data;
using E_Commerce.Models;
using E_Commerce.Repositories.IRepositories;
using Microsoft.EntityFrameworkCore;

namespace E_Commerce.Repositories.MRepositories
{
    public class ProductRepo : IProductRepo
    {
        private readonly AppDbContext con;

        public ProductRepo(AppDbContext con)
        {
            this.con = con;
        }

        public async Task deleteAsync(int id)
        {
            var Product = await con.Products.FindAsync(id);

            if (Product != null)
                con.Products.Remove(Product);

            await con.SaveChangesAsync();
        }

        public async Task<List<Product>> GetAllAsync()
        {
            var lstOfProducts = await con.Products.ToListAsync();

            return lstOfProducts;
        }

        public async Task<Product> GetByIdAsync(int id)
        {
            var Product = await con.Products.FindAsync(id);

            // await con.SaveChangesAsync();

            return Product;
        }

        public async Task insertAsync(Product entity)
        {
            await con.Products.AddAsync(entity);

            await con.SaveChangesAsync();
        }

        public async Task updateAsync(Product entity)
        {
            con.Products.Update(entity);

            await con.SaveChangesAsync();
        }

        //-----------------------------------------------------
        public async Task<IEnumerable<Product>> GetProductsByCategoryAsync(int CategoryId)
        {
            var ProductsOfCategory = await con.Products.Where(x  => x.CategoryId == CategoryId).ToListAsync();
            return ProductsOfCategory;
        }
    }
}
