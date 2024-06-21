using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace MvcProject.Web.CustomAttributes
{
	public class CustomAuthorizeAttribute : AuthorizeAttribute, IAuthorizationFilter
	{
		public void OnAuthorization(AuthorizationFilterContext context)
		{
			string? userName = context.HttpContext.Session.GetString("UserName");
			if (userName == null)
			{
				context.Result = new RedirectToActionResult("Index", "Login", null);
			}
		}
	}
}
