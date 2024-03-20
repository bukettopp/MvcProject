using BusinessLayer.Concrete;
using BusinessLayer.ValidationRules;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using FluentValidation.Results;
using Microsoft.AspNetCore.Mvc;

namespace MvcProject.Web.Controllers
{
    public class CategoryController : Controller
    {
        CategoryManager cm = new CategoryManager(new EfCategoryDal());
        public IActionResult Index()
        {
            return View();
        }
        public ActionResult GetCategoryList()
        {
            var categoryvalues = cm.GetList();
            return View(categoryvalues);

        }
        [HttpGet]
        public ActionResult AddCategory()
        {
            return View();
        }
        [HttpPost]
        public ActionResult AddCategory(Category p)
        {
          //cm.CategoryAddAlBL(p);
          CategoryValidator categoryValidator = new CategoryValidator();
           ValidationResult results = categoryValidator.Validate(p);
            if(results.IsValid)
            {
                cm.CategoryAdd(p);
                return RedirectToAction("GetCategoryList");
            }
            else
            {
                foreach (var item in results.Errors)
                {
                    ModelState.AddModelError(item.PropertyName, item.ErrorMessage);

                }
            }

            return View();
        }
    }
}
