using Microsoft.AspNetCore.Mvc.Rendering;

namespace E_Commerce.Services
{
    public interface ICategoryService
    {
        public Task<IEnumerable<SelectListItem>> GetAllCategories();
    }
}
