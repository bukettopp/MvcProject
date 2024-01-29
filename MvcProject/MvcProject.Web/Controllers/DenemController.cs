using Microsoft.AspNetCore.Mvc;

namespace MvcProject.Web.Controllers
{
    public class DenemController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
