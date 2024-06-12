using BusinessLayer.Concrete;
using BusinessLayer.ValidationRules;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Mvc;

namespace MvcProject.Web.Controllers
{
    public class ContactController : Controller
    {
        ContactManager cm = new(new EfContactDal());
        ContactValidator cv = new ContactValidator();

        public IActionResult Index()
        {
            var contactvalues = cm.GetList();
            return View(contactvalues);
        }
    }
}
