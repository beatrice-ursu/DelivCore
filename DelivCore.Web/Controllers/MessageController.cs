using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using DelivCore.BusinessLayer.MessageService;
using DelivCore.BusinessLayer.UserService;
using DelivCore.Models.Persons;

namespace DelivCore.Web.Controllers
{
    public class MessageController : Controller
    {
        private readonly IMessageService _messageService;
        private readonly IUserService _userService;

        public MessageController(IMessageService messageService, IUserService userService)
        {
            _messageService = messageService;
            _userService = userService;
        }

        [Authorize]
        public ActionResult Index()
        {
            return View();
        }

        [Authorize]
        public ActionResult GetMessages()
        {
            var messages = _messageService.GetMessagesByUser(User.Identity.Name);

            return new JsonResult
            {
                Data = new { data = messages },
                JsonRequestBehavior = JsonRequestBehavior.AllowGet,
                ContentType = "application/json"
            };
        }

        [System.Web.Mvc.HttpPost]
        public void SendMessage(List<MessageModel> messages)
        {
            _messageService.SaveMessage(messages, User.Identity.Name);
        }

        public async Task<ActionResult> PersonToList()
        {
            var model = await _userService.GetUsersList();
            return new JsonResult
            {
                Data = model.Select(x => new { id = x.Id, text = x.Text }),
                JsonRequestBehavior = JsonRequestBehavior.AllowGet,
                ContentType = "application/json"
            };
        }

        public void DeleteMessage(int id)
        {
            _messageService.DeleteMessage(id);
        }

        public ActionResult MessageDetails(int id)
        {
            var message = _messageService.GetById(id);
            return View("Details", message);
        }

        public void Replay()
        {
            
        }
    }
}