using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Threading.Tasks;
using System.Web.Mvc;
using DelivCore.BusinessLayer.MessageService;
using DelivCore.BusinessLayer.OrderService;
using DelivCore.BusinessLayer.UserService;
using DelivCore.Models.Layout;
using DelivCore.Models.Persons;
using DelivCore.DataLayer.Constants;

namespace DelivCore.Web.Controllers
{
    public class DashboardController : Controller
    {
        private readonly IOrderService _orderService;
        private readonly IUserService _userService;
        private readonly IMessageService _messageService;

        public DashboardController(IOrderService orderService, IUserService userService, IMessageService messageService)
        {
            _orderService = orderService;
            _userService = userService;
            _messageService = messageService;
        }

        #region Methods
        public ActionResult Index()
        {
            var groupOrders = _orderService.GroupOrders();
            return View("Index", groupOrders);
        }

        public ActionResult NavbarPartial()
        {
            var user = User.Identity.Name;
            var allOrders = _orderService.GroupOrdersByUser(user);

            var navbarModel = new NavbarModel();

            foreach (var item in allOrders)
            {
                switch (item.Status)
                {
                    case StatusConstants.Processed:
                        navbarModel.ProcessedToday++;
                        break;
                    case StatusConstants.Accepted:
                        if (item.UpdatedOn.Date == DateTime.Now.Date)
                            navbarModel.AcceptedToday++;
                        break;
                }
            }

            navbarModel.Messages = _messageService.GetMessagesByUser(user).Take(3).ToList();
            navbarModel.UserLoggedIn = user;

            return PartialView("_NavbarPartial", navbarModel);
        }

        #endregion

    }
}