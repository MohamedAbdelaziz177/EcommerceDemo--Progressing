using E_Commerce.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace E_Commerce.Controllers
{
    public class RoleController : Controller
    {
        private readonly RoleManager<ApplicationRole> roleManager;

        public RoleController(RoleManager<ApplicationRole> roleManager)
        {
            this.roleManager = roleManager;
        }
        public IActionResult Index()
        {
            return Content("Role Added Successfully");
        }

        [HttpGet]
        [Authorize(Roles = "admin")]
        public IActionResult AddRole()
        {

            return View();
        }


        [HttpPost]
        [AutoValidateAntiforgeryToken]
        [Authorize(Roles = "admin")]
        public async Task<IActionResult> SaveRole(AddRoleModel RoleVM)
        {
            if (!ModelState.IsValid)
            {
                return View("AddRole", RoleVM);
            }

            ApplicationRole role = new ApplicationRole();
            role.Name = RoleVM.RoleName;

           IdentityResult rslt = await roleManager.CreateAsync(role);

            if (rslt.Succeeded)
            {
                return RedirectToAction("Index");
            }

            else 
            {
                foreach (var errorItem in rslt.Errors) 
                {
                    ModelState.AddModelError("", errorItem.Description);
                }
            }


            return View("AddRole", role);
        }






    }
}
