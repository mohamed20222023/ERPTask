using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using TaskERP.BLL.ViewModels;

namespace TaskERP.Controllers
{
	[Authorize(Roles = "Admin")]
	public class RoleController : Controller
	{
		#region Properties

		public RoleManager<IdentityRole> RoleManager { get; }
		public UserManager<IdentityUser> UserManager { get; }
		#endregion

		#region Constructors
		public RoleController(RoleManager<IdentityRole> roleManager, UserManager<IdentityUser> userManager)
		{
			RoleManager = roleManager;
			UserManager = userManager;
		}
		#endregion

		#region Actions
		public IActionResult Index()
		{
			var Roles = RoleManager.Roles;
			return View(Roles);

		}


		public IActionResult Create()
		{
			return View();
		}


		[HttpPost]
		[ValidateAntiForgeryToken]
		public async Task<IActionResult> Create(IdentityRole role)
		{
			if (ModelState.IsValid)
			{
				try
				{
					var result = await RoleManager.CreateAsync(role);
					if (result.Succeeded)
						return RedirectToAction(nameof(Index));

					return RedirectToAction("Index");
				}
				catch (Exception ex)
				{
					return View(role);
				}
			}
			return View(role);

		}

		#endregion
	}
}
