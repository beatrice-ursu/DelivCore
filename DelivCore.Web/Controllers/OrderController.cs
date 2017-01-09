using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using DelivCore.BusinessLayer.DeliveryOfferService;
using DelivCore.BusinessLayer.DeliveryService;
using DelivCore.BusinessLayer.OrderOfferService;
using DelivCore.BusinessLayer.OrderService;
using DelivCore.Models.Orders;

namespace DelivCore.Web.Controllers
{
    public class OrderController : Controller
    {
        private readonly IOrderService _orderService;
        private readonly IOrderOfferService _orderOfferService;
        private readonly IDeliveryService _deliveryService;
        private readonly IDeliveryOfferService _deliveryOfferService;

        public OrderController(IOrderService orderService, IOrderOfferService orderOfferService, IDeliveryService deliveryService, IDeliveryOfferService deliveryOfferService)
        {
            _orderService = orderService;
            _orderOfferService = orderOfferService;
            _deliveryService = deliveryService;
            _deliveryOfferService = deliveryOfferService;
        }

        #region Methods
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult GetOrders(IList<OrderModel> filteredList = null)
        {
            var orders = filteredList?.ToList() ?? _orderService.GetAll().ToList();

            return new JsonResult
            {
                Data = new { data = orders },
                JsonRequestBehavior = JsonRequestBehavior.AllowGet,
                ContentType = "application/json"
            };
        }

        public ActionResult GetDetails(int id)
        {
            var ordersDetails = _orderService.GetById(id);

            return View("Details", ordersDetails);
        }

        public ActionResult GetDeliveryOffers(int Id)
        {
            //var results = new List<DeliveryOfferModel>
            //{
            //    new DeliveryOfferModel
            //    {
            //        Id = 1,
            //        CourierId = 1,
            //        Time = DateTime.Now.TimeOfDay,
            //    },
            //    new DeliveryOfferModel
            //    {
            //        CourierId = 2,
            //        Time = DateTime.Now.TimeOfDay,
            //    }
            //};
            var results = _deliveryOfferService.GetAllById(Id);
            return Json(new {data = results}, JsonRequestBehavior.AllowGet);
        }

        [System.Web.Mvc.HttpPost]
        public void AddOrderOffer(int orderId,string description)
        {
            _orderOfferService.CreateOrderOffer(orderId,description);
        }

        public void AcceptOffer(int id)
        {
            _deliveryService.AcceptOffer(id);
        }
        #endregion


    }
}