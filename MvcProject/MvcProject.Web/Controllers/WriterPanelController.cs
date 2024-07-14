using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace MvcProject.Web.Controllers
{
	public class WriterPanelController : Controller
	{
		HeadingManager hm = new(new EfHeadingDal());
		CategoryManager cm = new(new EfCategoryDal());
		public IActionResult WriterProfile()
		{
			return View();
		}
		public IActionResult MyHeading()
		{
			
			var values = hm.GetListByWriter();
			return View(values);
		}

		[HttpGet]
		public IActionResult NewHeading()
		{
			List<SelectListItem> valuecategory = (from x in cm.GetList()
												  select new SelectListItem
												  {
													  Text = x.CategoryName,
													  Value = x.CategoryID.ToString()

												  }
			 ).ToList();
			return View();
		}
		[HttpPost]
		public IActionResult NewHeading(Heading p)
		{
			p.HeadingDate = DateTime.Parse(DateTime.Now.ToShortDateString());
			p.WriterID = 4;
			p.HeadingStatus = true;
			hm.HeadingAdd(p);
			return RedirectToAction("Index");
			
		}
	}
}
