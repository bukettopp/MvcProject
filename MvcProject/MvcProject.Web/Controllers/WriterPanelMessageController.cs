using BusinessLayer.Concrete;
using BusinessLayer.ValidationRules;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Mvc;

namespace MvcProject.Web.Controllers
{
    public class WriterPanelMessageController : Controller
    {
        MessageManager mm = new(new EfMessageDal());
        MessageValidator messageValidator = new MessageValidator();
        public IActionResult Inbox()
        {
            var messageList = mm.GetListInbox();
            return View(messageList);
        }


        public PartialViewResult MessageListMenu() {

            return PartialView();
        }
    }
}
