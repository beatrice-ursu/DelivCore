using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DelivCore.BusinessLayer.PersonService;

namespace DelivCore.Web.Controllers
{
    [Authorize]
    public class PersonController : Controller
    {
        private readonly IPersonService _personService;
        public PersonController(IPersonService personService)
        {
            _personService = personService;
        }
        
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult GetUsers()
        {
            var users = _personService.GetAllUsersFromDB();

            return new JsonResult
            {
                Data = new { data = users },
                JsonRequestBehavior = JsonRequestBehavior.AllowGet,
                ContentType = "application/json"
            };
        }

    }
}