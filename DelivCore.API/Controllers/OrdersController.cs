using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using DelivCore.Models.Orders;

namespace DelivCore.API.Controllers
{
    public class OrdersController : ApiController
    {
        //private readonly IOrderService _orderService;
        //public OrdersController(IOrderService orderService)
        //{
        //    _orderService = orderService;
        //}

        public IHttpActionResult OpenOrders()
        {
            var orders = new List<OrderOfferModel>();
            return Ok(orders);
        }

        [HttpPost]
        public IHttpActionResult DeliveryOffer([FromBody] DeliveryOfferModel deliveryOffer)
        {
            //gen accepted/rejected
            //var status = _orderService.MakeOffer(deliveryOffer);
            return Ok();
        }
    }
}
