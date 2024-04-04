using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Mvc;

namespace MvcProject.Web.Controllers
{
    public class ContentController : Controller
    {
        ContentManager cm = new(new EfContentDal());
        WriterManager wm = new(new EfWriterDal());
        HeadingManager hm = new(new EfHeadingDal());
        public IActionResult Index()
        {
            return View();
        }
        public ActionResult ContentByHeading(int id)
        {
            var contentvalues=cm.GetListByHeadingID(id);
            return View(contentvalues);
        }
    }
}
