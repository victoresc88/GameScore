using System.Threading.Tasks;
using GameScore.BL.Interfaces;
using GameScore.UI.ViewModels;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace GameScore.UI.Controllers
{
	public class AccountController : Controller
	{
		private readonly IAccountBusiness _accountBusiness;

		public AccountController(IAccountBusiness accountBusiness)
		{
			_accountBusiness = accountBusiness;
		}

		[AllowAnonymous]
		public IActionResult Login(string returnUrl = "/")
		{
			return View(new LoginViewModel { ReturnUrl = returnUrl });
		}

		[AllowAnonymous]
		public IActionResult Register(string returnUrl = "/")
		{
			return View(new RegisterViewModel { ReturnUrl = returnUrl });
		}

		[HttpPost]
		[AllowAnonymous]
		public async Task<IActionResult> Login(LoginViewModel viewModel)
		{
			var user = _accountBusiness.GetUserByUsernameAndPassword(viewModel.Username, viewModel.Password);
			if (user == null)
				return Unauthorized();

			var principal = _accountBusiness.CreateClaimsPrincipal(user, CookieAuthenticationDefaults.AuthenticationScheme);

			await HttpContext.SignInAsync(
				 CookieAuthenticationDefaults.AuthenticationScheme,
				 principal,
				 new AuthenticationProperties { IsPersistent = viewModel.RememberLogin }
			);

			return LocalRedirect(viewModel.ReturnUrl);
		}

		[HttpPost]
		[AllowAnonymous]
		public async Task<IActionResult> Register(RegisterViewModel viewModel)
		{
			var user = _accountBusiness.CreateNewUser(viewModel.Username, viewModel.Password);
			if (user == null)
				return Unauthorized();

			var principal = _accountBusiness.CreateClaimsPrincipal(user, CookieAuthenticationDefaults.AuthenticationScheme);

			await HttpContext.SignInAsync(
				 CookieAuthenticationDefaults.AuthenticationScheme,
				 principal,
				 new AuthenticationProperties { IsPersistent = false }
			);

			return LocalRedirect(viewModel.ReturnUrl);
		}

		public async Task<IActionResult> Logout()
		{
			await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);

			return Redirect("/");
		}
	}
}