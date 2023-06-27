using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace TaskERP.Controllers
{
	[Authorize(Roles = "Admin")]
	public class UserController : Controller
	{
		#region Properties

		public UserManager<IdentityUser> UserManager { get; }
		#endregion

		#region Constructors
		public UserController(UserManager<IdentityUser> userManager)
		{
			UserManager = userManager;
		}
		#endregion

		#region Actions
		public IActionResult Index()
		{
			var Users = UserManager.Users;
			return View(Users);

		}
		public async Task<IActionResult> Details(string id, string ViewName = "Details")
		{
			if (id == null)
				return RedirectToAction(nameof(NotFound));
			var User = await UserManager.FindByIdAsync(id);
			if (User == null)
				return RedirectToAction(nameof(NotFound));
			return View(ViewName, User);
		}
		#endregion

	}
}

