using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Mvc;

namespace MvcProject.Web.Controllers
{
    public class HeadingController : Controller
    {
        HeadingManager hm = new(new EfHeadingDal());
        public IActionResult Index()
        {
            var headingvalues = hm.GetList();
            return View(headingvalues);
        }
    }
}
