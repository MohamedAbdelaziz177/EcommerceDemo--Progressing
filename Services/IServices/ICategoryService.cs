using Microsoft.AspNetCore.Mvc.Rendering;

namespace E_Commerce.Services.IServices
{
    public interface ICategoryService
    {
        public Task<IEnumerable<SelectListItem>> GetAllCategories();
    }
}
