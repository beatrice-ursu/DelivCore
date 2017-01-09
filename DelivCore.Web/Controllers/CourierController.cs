using DelivCore.BusinessLayer.PersonService;
using System.Web.Mvc;

namespace DelivCore.Web.Controllers
{
    public class CourierController : Controller
    {
        private readonly IPersonService _personService;

        public CourierController(IPersonService personService)
        {
            _personService = personService;
        }

        #region Methods

        [Authorize]
        public ActionResult Index()
        {
            return View();
        }

        [Authorize]
        public ActionResult GetCouriers()
        {
            var couriers = _personService.GetCouriers();

            return new JsonResult
            {
                Data = new { data = couriers },
                JsonRequestBehavior = JsonRequestBehavior.AllowGet,
                ContentType = "application/json"
            };
        }
        #endregion
    }
}