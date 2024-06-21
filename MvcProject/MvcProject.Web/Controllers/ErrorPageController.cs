using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;

namespace MvcProject.Web.Controllers
{
	public class ErrorPageController : Controller
	{
		public IActionResult Page404(int code)
		{
			return View();
		}
	}
}
