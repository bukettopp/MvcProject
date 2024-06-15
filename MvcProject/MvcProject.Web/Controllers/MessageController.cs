using BusinessLayer.Concrete;
using BusinessLayer.ValidationRules;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace MvcProject.Web.Controllers
{
    public class MessageController : Controller
    {
       MessageManager cm = new(new EfMessageDal());
       // ContactValidator cv = new ContactValidator();
        public IActionResult Inbox()
        {
            var messageList = cm.GetListInbox();
            return View(messageList);
        }
        public ActionResult Sendbox() {
        
        var messageList = cm.GetListSendbox();  
            return View(messageList);
        }
        [HttpGet]
        public ActionResult NewMessage()
        {

            return View();
        }
        [HttpPost]
        public ActionResult NewMessage(Message p)
        {
            return View();

        }
    }
}
