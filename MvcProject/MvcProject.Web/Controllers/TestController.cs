using Microsoft.AspNetCore.Mvc;

namespace MvcProject.Web.Controllers
{
    public class TestController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
