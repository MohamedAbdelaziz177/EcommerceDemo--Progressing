using E_Commerce.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace E_Commerce.Controllers
{
	public class AccountController : Controller
	{

		/* Dependency Injecting The Coupled Services */

		readonly private UserManager<ApplicationUser> UserManager;
        private readonly SignInManager<ApplicationUser> signInManager;

        public AccountController(UserManager<ApplicationUser> userManager,
			SignInManager<ApplicationUser> signInManager
			)
		{
			UserManager = userManager;
            this.signInManager = signInManager;
        }

		

		public IActionResult Index()
		{
			return View();
		}

		[HttpGet]
		public IActionResult Register()
		{
			return View();
		}

		[HttpPost]
		[AutoValidateAntiforgeryToken]
		public async Task<IActionResult> SaveRegister(UserRegForm user)
		{
			if (!ModelState.IsValid)
			{
				return View(user);
			}

            ApplicationUser newUser = new ApplicationUser();

			newUser.UserName = user.UserName;
			newUser.Email = user.Email;
			newUser.Address = user.Address;
			newUser.PasswordHash = user.Password;

			IdentityResult rslt = await UserManager.CreateAsync(newUser, user.Password); // Takes ApplicationUser argument

			if (rslt.Succeeded)
			{
				// Create Cookie

				await UserManager.AddToRoleAsync(newUser, "user");
				await signInManager.SignInAsync(newUser, isPersistent: false);

				return View("Index");
			}

			else
			{
				

				foreach (var item in rslt.Errors) {

					ModelState.AddModelError("", item.Description);
				}

				return View("Register", user);
			}

			return View("Register", user);

			
		}


		[HttpGet]
		public IActionResult Login()
		{
			return View();
		}

		[HttpPost]
		[AutoValidateAntiforgeryToken]
		public async Task<IActionResult> SaveLogin(LoginForm user)
		{
			if (!ModelState.IsValid) 
			{
				return View("Login", user);
			}

			
			var EmailExists = await UserManager.FindByNameAsync(user.Name);

			if (EmailExists != null) 
			{
				var PasswordMatched = await UserManager.CheckPasswordAsync(EmailExists, user.Password);

				if (PasswordMatched) 
				{

					await signInManager.SignInAsync(EmailExists, user.RememberMe);
					return RedirectToAction( "Index");
				}
			}

			ModelState.AddModelError("", "Password or username is incorrect");

			return View("Login", user);
		}


        
        public async Task<IActionResult> LogOut()
		{
			await signInManager.SignOutAsync();
			// return RedirectToAction("Index");
			return RedirectToAction("Index");
		}


		[HttpGet]
        [Authorize(Roles = "admin")]

        public IActionResult AddAdmin() 
		{ 
			return View();
		}

		[HttpPost]
        [Authorize(Roles = "admin")]
        public async Task<IActionResult> SaveAdmin(UserRegForm user)
		{

            if (!ModelState.IsValid)
            {
                return View(user);
            }

            ApplicationUser newUser = new ApplicationUser();

            newUser.UserName = user.UserName;
            newUser.Email = user.Email;
            newUser.Address = user.Address;
            newUser.PasswordHash = user.Password;

            IdentityResult rslt = await UserManager.CreateAsync(newUser, user.Password); // Takes ApplicationUser argument

            if (rslt.Succeeded)
            {
                // Create Cookie

               await UserManager.AddToRoleAsync(newUser, "admin");


                await signInManager.SignInAsync(newUser, isPersistent: false);

                return View("Index");
            }

            else
            {


                foreach (var item in rslt.Errors)
                {

                    ModelState.AddModelError("", item.Description);
                }

                return View("AddAdmin", user);
            }

            return View("AddAdmin", user);

        }
    }
}
