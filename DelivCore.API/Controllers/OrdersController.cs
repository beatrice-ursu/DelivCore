using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using DelivCore.BusinessLayer.OrderService;
using DelivCore.Models.Orders;

namespace DelivCore.API.Controllers
{
    [RoutePrefix("api/Orders")]
    public class OrdersController : BaseApiController
    {
        private readonly IOrderService _ordersService;
        public OrdersController(IOrderService orderService)
        {
            _ordersService = orderService;
        }

        [Route("GetOpenOrders")]
        [HttpGet]
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

        [Route("SaveOrders")]
        [HttpPost]
        public IHttpActionResult SaveOrders([FromBody]IEnumerable<OrderDto> orders)
        {
            if (orders == null || orders.Count() == 0) return BadRequest();

            if (_ordersService.SaveOrders(orders))
                return Ok();
            return InternalServerError();
        }
    }
}
