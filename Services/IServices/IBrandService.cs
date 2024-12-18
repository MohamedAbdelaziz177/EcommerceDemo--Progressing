using Microsoft.AspNetCore.Mvc.Rendering;

namespace E_Commerce.Services.IServices
{
    public interface IBrandService
    {
        public Task<IEnumerable<SelectListItem>> GetAllBrands();


    }
}
