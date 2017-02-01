using System.Linq;
using System.Web.Mvc;
using DelivCore.BusinessLayer.DeliveryOfferService;
using DelivCore.BusinessLayer.DeliveryService;
using DelivCore.BusinessLayer.OrderOfferService;
using DelivCore.BusinessLayer.OrderService;
using DelivCore.BusinessLayer.UserService;
using System.Threading.Tasks;

namespace DelivCore.Web.Controllers
{
    public class OrderController : Controller
    {
        private readonly IOrderService _orderService;
        private readonly IOrderOfferService _orderOfferService;
        private readonly IDeliveryService _deliveryService;
        private readonly IDeliveryOfferService _deliveryOfferService;
        private readonly IUserService _userService;

        public OrderController(IOrderService orderService, IOrderOfferService orderOfferService, IDeliveryService deliveryService, IDeliveryOfferService deliveryOfferService, IUserService userService)
        {
            _orderService = orderService;
            _orderOfferService = orderOfferService;
            _deliveryService = deliveryService;
            _deliveryOfferService = deliveryOfferService;
            _userService = userService;
        }

        #region Methods
        [Authorize]
        public ActionResult Index(string status = null)
        {
            ViewBag.Status = status;
            return View();
        }

        [Authorize]
        public ActionResult GetOrders(string filter)
        {
            var orders = filter != null ? _orderService.GetAll().Where(x => x.Status == filter).ToList() : _orderService.GetAll().ToList();

            return new JsonResult
            {
                Data = new { data = orders },
                JsonRequestBehavior = JsonRequestBehavior.AllowGet,
                ContentType = "application/json"
            };
        }

        [Authorize]
        public ActionResult GetDetails(int id)
        {
            var ordersDetails = _orderService.GetById(id);

            return View("Details", ordersDetails);
        }

        [Authorize]
        public ActionResult GetDeliveryOffers(int Id)
        {
            var results = _deliveryOfferService.GetAllById(Id);
            return Json(new {data = results}, JsonRequestBehavior.AllowGet);
        }
        
        [Authorize]
        [System.Web.Mvc.HttpPost]
        public void AddOrderOffer(int orderId,string description)
        {
            _orderOfferService.CreateOrderOffer(orderId,description);
        }

        [Authorize]
        public ActionResult AcceptOffer(int id)
        {
            _deliveryService.AcceptOffer(id, User.Identity.Name);
            return RedirectToAction("Index");
        }
        #endregion


    }
}