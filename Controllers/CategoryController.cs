using E_Commerce.Models;
using E_Commerce.Repositories.IRepositories;
using E_Commerce.Services.IServices;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace E_Commerce.Controllers
{
    public class CategoryController : Controller
    {
        private readonly ICategoryRepo categoryRepo;
        private readonly ICategoryService categoryService;

        public CategoryController(ICategoryRepo categoryRepo, ICategoryService categoryService)
        {
            this.categoryRepo = categoryRepo;
            this.categoryService = categoryService;
        }


        public IActionResult Index()
        {
            return View();
        }

        public async Task<IActionResult> GetCategoryDetails(int id)
        {
           Category category = await categoryRepo.GetByIdAsync(id);
           return View(category);
        }

        [HttpGet]
        [Authorize(Roles = "admin")]
        public IActionResult AddCategory()
        {

            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "admin")]
        public async  Task<IActionResult> SaveNewCategory(Category category)
        {
            ModelState.Remove("Products");

            if (ModelState.IsValid)
            {
                await categoryRepo.insertAsync(category);

                return RedirectToAction("GetAllCategories");
            }

            else

            return View("AddCategory", category);
        }

        [Authorize(Roles = "admin")]
        public async Task<IActionResult> RemoveCategory(int id)
        {
            await categoryRepo.deleteAsync(id);

            return RedirectToAction("GetAllCategories");
        }


        [HttpGet]
        [Authorize(Roles = "admin")]
        public async Task<IActionResult> EditCategory(int id)
        {
            Category category = await categoryRepo.GetByIdAsync(id);
            ViewData["categories"] = await categoryService.GetAllCategories();


            return View(category);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "admin")]
        public async Task<IActionResult> SaveEdit(Category category)
        {
            ModelState.Remove("Products");

            if (ModelState.IsValid) 
            {
               await categoryRepo.updateAsync(category);
               return RedirectToAction("GetAllCategories");
            }

            return View("EditCategory", category);
        }


        //----------------------------------------------------------
        public async Task<IActionResult> GetAllCategories()
        {

            List<Category> categories =  await categoryRepo.GetAllAsync();
            return View(categories);

        }
    }
}
