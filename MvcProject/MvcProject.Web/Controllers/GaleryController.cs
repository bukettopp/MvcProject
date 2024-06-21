using BusinessLayer.Concrete;
using DataAccessLayer.Abstract;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Mvc;

namespace MvcProject.Web.Controllers
{
	public class GaleryController : Controller
	{
		ImageFileManager ifm = new(new EfImageFileDal());
		public IActionResult Index()
		{
			var files = ifm.GetList();
			return View(files);
		}
	}
}
