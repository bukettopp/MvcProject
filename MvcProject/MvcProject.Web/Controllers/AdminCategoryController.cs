﻿using BusinessLayer.Concrete;
using BusinessLayer.ValidationRules;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using FluentValidation.Results;
using Microsoft.AspNetCore.Mvc;
using MvcProject.Web.CustomAttributes;

namespace MvcProject.Web.Controllers
{
	
	public class AdminCategoryController : Controller
    {
        CategoryManager cm = new(new EfCategoryDal());

		[CustomAuthorize(Roles =  "B")]
		public IActionResult Index()
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
		public ActionResult AddCategory(Category p )
		{
            CategoryValidator validator = new CategoryValidator();  
            ValidationResult results = validator.Validate(p);
            if (results.IsValid)
            {
                cm.CategoryAdd(p);
                return RedirectToAction("Index");
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


        public ActionResult DeleteCategory(int id)
        {

            var categoryvalue=cm.GetByID(id);
            cm.CategoryDelete(categoryvalue);
            return RedirectToAction("Index");  
        }

        [HttpGet]
        public ActionResult EditCategory(int id)
        {
            var categoryvalue = cm.GetByID(id);
            return View(categoryvalue);
		}
        [HttpPost]
        public ActionResult EditCategory(Category p)
        {
            
           cm.CategoryUpdate(p);
            return RedirectToAction("Index");
        }
    }
}
