
using E_Commerce.Data;
using E_Commerce.Models;
using E_Commerce.Repositories.IRepositories;
using Microsoft.EntityFrameworkCore;

namespace E_Commerce.Repositories.MRepositories
{
    public class BrandRepo : IBrandRepo
    {
        private readonly AppDbContext con;

        public BrandRepo(AppDbContext con)
        {
            this.con = con;
        }
        public async Task deleteAsync(int id)
        {
            var brand = await con.Brands.FindAsync(id);

            if(brand != null) 
            con.Brands.Remove(brand);

            await con.SaveChangesAsync();

        }

        public async Task<List<Brand>> GetAllAsync()
        {
            var lstOfBrands = await con.Brands.ToListAsync();

            return lstOfBrands;
        }

        public async Task<Brand> GetByIdAsync(int id)
        {
            var brand = await con.Brands.FindAsync(id);

           // await con.SaveChangesAsync();

            return brand;
        }

        public async Task insertAsync(Brand entity)
        {
            await con.Brands.AddAsync(entity);

            await con.SaveChangesAsync();

        }

        public async Task updateAsync(Brand entity)
        {
            con.Brands.Update(entity);


            await con.SaveChangesAsync();
        }
    }
}
