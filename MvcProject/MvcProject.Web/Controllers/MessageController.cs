using BusinessLayer.Concrete;
using BusinessLayer.ValidationRules;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using FluentValidation.Results;
using Microsoft.AspNetCore.Mvc;

namespace MvcProject.Web.Controllers
{
    public class MessageController : Controller
    {
       MessageManager mm = new(new EfMessageDal());
       MessageValidator messageValidator = new MessageValidator();
        public IActionResult Inbox()
        {
            var messageList = mm.GetListInbox();
            return View(messageList);
        }
        public ActionResult Sendbox() {
        
        var messageList = mm.GetListSendbox();  
            return View(messageList);
        }
		public ActionResult GetInBoxMessageDetails(int id)
		{
			var Values = mm.GetByID(id);
			return View(Values);
		}

		public ActionResult GetSendBoxMessageDetails(int id)
		{
			var Values = mm.GetByID(id);
			return View(Values);
		}



		[HttpGet]
        public ActionResult NewMessage()
        {

            return View();
        }
        [HttpPost]
        public ActionResult NewMessage(Message p)
        {
            ValidationResult results = messageValidator.Validate(p);
            if (results.IsValid)
            {
                p.MessageDate = DateTime.Parse(DateTime.Now.ToShortDateString());       ;
                mm.MessageAdd(p);
                return RedirectToAction("SendBox");
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
