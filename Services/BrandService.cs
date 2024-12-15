using E_Commerce.Data;
using E_Commerce.Repositories.IRepositories;
using E_Commerce.Repositories.MRepositories;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace E_Commerce.Services
{
    public class BrandService : IBrandService
    {
       
        private readonly IBrandRepo brandRepo;

        public BrandService(IBrandRepo brandRepo)
        {
           
            this.brandRepo = brandRepo;
        }

        public async Task<IEnumerable<SelectListItem>> GetAllBrands()
        {
            var lst = await brandRepo.GetAllAsync();

            var brands = new SelectList(lst, "BrandId", "Name"); ;

            return brands;
        }
    }
}
