using BusinessLayer.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace MvcProject.Web.Controllers
{
    public class CategoryController : Controller
    {
        CategoryManager cm = new CategoryManager();
        public IActionResult Index()
        {
            return View();
        }
        public ActionResult GetCategoryList()
        {
            var categoryvalues = cm.GetAllBL();
            return View(categoryvalues);

        }
    }
}
