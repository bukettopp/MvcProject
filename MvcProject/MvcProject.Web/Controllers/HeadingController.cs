using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace MvcProject.Web.Controllers
{
    public class HeadingController : Controller
    {
        HeadingManager hm = new(new EfHeadingDal());
        CategoryManager cm = new(new EfCategoryDal());
        WriterManager wm = new(new EfWriterDal());
        public IActionResult Index()
        {
            var headingvalues = hm.GetList();
            return View(headingvalues);
        }
        [HttpGet]
        public ActionResult AddHeading()
        {
            List<SelectListItem> valuecategory = (from x in cm.GetList()
                                                  select new SelectListItem
                                                  {
                                                      Text = x.CategoryName,
                                                      Value = x.CategoryID.ToString()

                                                  }
              ).ToList();
          



            List<SelectListItem> valuewriter = (from w in wm.GetList()
                                                select new SelectListItem
                                                {
                                                    Text = w.WriterName + " " + w.WriterSurname,
                                                    Value = w.WriterID.ToString()
                                                }  ).ToList();
            ViewBag.vlc = valuecategory;
            ViewBag.vlw = valuewriter;

            return View();
        }

        [HttpPost]
        public ActionResult AddHeading(Heading p)
        {
            p.HeadingDate = DateTime.Parse(DateTime.Now.ToShortDateString());
            hm.HeadingAdd(p);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult  EditHeading(int id)
        {
            List<SelectListItem> valuecategory = (from x in cm.GetList()
                                                  select new SelectListItem
                                                  {
                                                      Text = x.CategoryName,
                                                      Value = x.CategoryID.ToString()

                                                  }
            ).ToList();
            ViewBag.vlc = valuecategory;
            var headingvalues = hm.GetByID(id);   return View(headingvalues);
        }
        [HttpPost]
        public ActionResult EditHeading(Heading p)
        {
            hm.HeadingUpdate(p);
            return RedirectToAction("Index");
        }
        public ActionResult   DeleteHeading(int id)
        {
            var heading = hm.GetByID(id);
            hm.HeadingDelete(heading);
                return RedirectToAction("Index");
        }
    }
}
