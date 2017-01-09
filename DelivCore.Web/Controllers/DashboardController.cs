using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
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
        public ActionResult Index()
        {
            var groupOrders = _orderService.GroupOrders();
            return View("Index", groupOrders);
        }

        public ActionResult FilterList([FromBody]string status)
        {
            var list = _orderService.GetAll().Where(x => x.Status == status).ToList();
             return RedirectToAction("GetOrders", "Order", list);
        }
    }
}