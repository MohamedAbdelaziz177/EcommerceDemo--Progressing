using E_Commerce.Data;
using E_Commerce.Repositories.IRepositories;
using E_Commerce.Repositories.MRepositories;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace E_Commerce.Services
{
    public class CategoryService : ICategoryService
    {
       
        private readonly ICategoryRepo catRepo;

        public CategoryService( ICategoryRepo catRepo)
        {
           
            this.catRepo = catRepo;
        }
        public async Task<IEnumerable<SelectListItem>> GetAllCategories()
        {
            var lst = await catRepo.GetAllAsync();

            var categories =  new SelectList(lst ,"CategoryId", "Name");

            return categories;
        }
    }
}
