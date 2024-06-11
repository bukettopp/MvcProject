using Microsoft.AspNetCore.Mvc;

namespace MvcProject.Web.Controllers
{
    public class ContactController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
