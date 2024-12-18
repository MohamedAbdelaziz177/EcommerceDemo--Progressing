
using E_Commerce.Data;
using E_Commerce.Models;
using E_Commerce.Repositories.IRepositories;
using Microsoft.EntityFrameworkCore;

namespace E_Commerce.Repositories.MRepositories
{
    public class CategoryRepo : ICategoryRepo
    {

        private readonly AppDbContext con;

        public CategoryRepo(AppDbContext con)
        {
            this.con = con;
        }

        public async Task deleteAsync(int id)
        {
            var category = await con.Categories.FindAsync(id);

            if (category != null)
                con.Categories.Remove(category);

            await con.SaveChangesAsync();

        }

        public async Task<List<Category>> GetAllAsync()
        {
            var lstOfCategories = await con.Categories.ToListAsync();

            return lstOfCategories;
        }

        public async Task<Category> GetByIdAsync(int id)
        {
            var category = await con.Categories.FindAsync(id);

          //  await con.SaveChangesAsync();

            return category;
        }

        public async Task insertAsync(Category entity)
        {
            await con.Categories.AddAsync(entity);

            await con.SaveChangesAsync();

        }

        public async Task updateAsync(Category entity)
        {
            con.Categories.Update(entity);

            await con.SaveChangesAsync();
        }
    }
}
