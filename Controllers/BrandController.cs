using E_Commerce.Models;
using E_Commerce.Repositories.IRepositories;
using E_Commerce.Repositories.MRepositories;
using E_Commerce.Services.IServices;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace E_Commerce.Controllers
{
    public class BrandController : Controller
    {
        private readonly IBrandRepo brandRepo;
        private readonly IBrandService brandService;

        public BrandController(IBrandRepo brandRepo, IBrandService brandService)
        {
            this.brandRepo = brandRepo;
            this.brandService = brandService;
        }

        public IActionResult Index()
        {
            return View();
        }

        public async Task<IActionResult> GetBrandDetails(int id)
        {

            Brand brand = await brandRepo.GetByIdAsync(id);
            return View(brand);

        }

        [HttpGet]
        [Authorize(Roles = "admin")]
        public async Task<IActionResult> AddBrand()
        {
            ViewData["brands"] = await brandService.GetAllBrands();
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "admin")]
        public async Task<IActionResult> SaveNewBrand(Brand brand)
        {
            ModelState.Remove("Products");

            if (ModelState.IsValid)
            {
                await brandRepo.insertAsync(brand);

                return RedirectToAction("GetAllBrands");
            }

            else

                return View("AddBrand", brand);
        }

        [Authorize(Roles = "admin")]
        public async Task<IActionResult> RemoveBrand(int id)
        {
            await brandRepo.deleteAsync(id);

            return RedirectToAction("GetAllBrands");
        }


        [HttpGet]
        [Authorize(Roles = "admin")]
        public async Task<IActionResult> EditBrand(int id)
        {
            ViewData["brands"] = await brandService.GetAllBrands();

            Brand brand = await brandRepo.GetByIdAsync(id);
            return View(brand);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "admin")]
        public async Task<IActionResult> SaveEdit(Brand brand)
        {
            ModelState.Remove("Products");

            if (ModelState.IsValid)
            {
                await brandRepo.updateAsync(brand);
                return RedirectToAction("GetAllBrands");
            }

            return View("EditBrand", brand);
        }


        //----------------------------------------------------------
        public async Task<IActionResult> GetAllBrands()
        {

            List<Brand> brands = await brandRepo.GetAllAsync();
            return View(brands);

        }


    }
}
