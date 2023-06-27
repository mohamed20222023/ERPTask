using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using TaskERP.BLL.ViewModels;

namespace TaskERP.Controllers
{
	public class AccountController : Controller
	{
		public UserManager<IdentityUser> UserManager { get; }
		public SignInManager<IdentityUser> SignInManager { get; }

		public AccountController(UserManager<IdentityUser> userManager, SignInManager<IdentityUser> signInManager)
		{
			UserManager = userManager;
			SignInManager = signInManager;
		}

		#region Sign Up

		public IActionResult Register()
		{
			return View();
		}

		[HttpPost]
		public async Task<IActionResult> Register(RegisterViewModel model)
		{
			if (ModelState.IsValid)
			{
				var user = new IdentityUser
				{
					UserName = model.UserName,
					Email = model.Email,
					
				};

				
				var result = await UserManager.CreateAsync(user, model.Password);
				if (result.Succeeded)
					return RedirectToAction(nameof(Login));
				foreach (var error in result.Errors)
					ModelState.AddModelError(string.Empty, error.Description);
				await UserManager.AddToRoleAsync(user, "User");
			}
			return View(model);
		}
		#endregion



		#region Sign In

		public IActionResult Login()
		{
			return View();
		}

		[HttpPost]
		public async Task<IActionResult> Login(LoginViewModel model)
		{
			if (ModelState.IsValid)
			{
				var user = await UserManager.FindByEmailAsync(model.Email);
				if (user != null )
				{
					var passwordIsValid = await UserManager.CheckPasswordAsync(user, model.Password);
					if (passwordIsValid)
					{
						await SignInManager.SignInAsync(user, true);
						var role = await UserManager.GetRolesAsync(user);
						foreach (var item in role)
						{
							if (item == "Admin")
								return RedirectToAction("AdminIndex", "Home");
						}
						return RedirectToAction("Index", "Home");
					}
					
				}
				ModelState.AddModelError(string.Empty, "Invalid Email or Password");
			}
			return View(model);
		}
		#endregion

		#region Sign Out

		public async new Task<IActionResult> SignOut()
		{
			await SignInManager.SignOutAsync();
			return RedirectToAction(nameof(Login));
		}

		#endregion
	}
}
