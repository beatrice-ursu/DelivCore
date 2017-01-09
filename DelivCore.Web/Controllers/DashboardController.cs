using System.Web.Mvc;
using DelivCore.BusinessLayer.OrderService;

namespace DelivCore.Web.Controllers
{
    public class DashboardController : Controller
    {
        private readonly IOrderService _orderService;

        public DashboardController(IOrderService orderService)
        {
            _orderService = orderService;
        }

        #region Methods
        //[Authorize]
        public ActionResult Index()
        {
            var groupOrders = _orderService.GroupOrders();
            return View("Index", groupOrders);
        }

        //[Authorize]
        public PartialViewResult NavbarPartial()
        {
            var userLoggedIn = User.Identity.Name;
            var model = _orderService.GroupOrdersByUser(userLoggedIn);

            return PartialView("_NavbarPartial", model);
        }
        #endregion

    }
}