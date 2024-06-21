using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using System.Text;

namespace MvcProject.Web.Controllers
{
	public class LoginController : Controller
	{
		LoginManager lm = new(new EfLoginDal());
		[HttpGet]
		public IActionResult Index()
		{ 
			return View();
		}

		[HttpPost]
		public async Task<IActionResult> Index(Admin p )
		{
			Admin? adminuserinfo= lm.Login(p.AdminUserName,p.AdminPassword);
			if (adminuserinfo != null)
			{
				HttpContext.Session.SetString("UserName",adminuserinfo.AdminUserName);
				#region Authorize
				//var claims = new List<Claim> 
				//{
				//	new Claim(ClaimTypes.Name, adminuserinfo.AdminUserName),
				//	new Claim("UserSession", adminuserinfo.AdminUserName)
				//};

				//var claimsIdentity = new ClaimsIdentity(claims, "SessionScheme");

				//var authProperties = new AuthenticationProperties 
				//{
				//	IsPersistent = true,
				//};

				//await HttpContext.SignInAsync("SessionScheme", new ClaimsPrincipal(claimsIdentity), authProperties); 
				#endregion
				return RedirectToAction("Index","AdminCategory");
			}
			else
			{
				return RedirectToAction("Index");
			}
			
		}
	}
}
