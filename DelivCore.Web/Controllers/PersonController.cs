using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DelivCore.BusinessLayer.PersonService;
using DelivCore.DataLayer.Constants;
using DelivCore.Models.Persons;

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

        [Authorize]
        public ActionResult Index()
        {
            return View();
        }

        [Authorize]
        [HttpGet]
        public ActionResult GetPersons()
        {
            var persons = _personService.GetAllPersonsFromDB();

            return new JsonResult
            {
                Data = new { data = persons },
                JsonRequestBehavior = JsonRequestBehavior.AllowGet,
                ContentType = "application/json"
            };
        }

        public ActionResult AddPerson(int id = 0)
        {
            var model = id != 0 ? _personService.GetById(id) : new PersonModel();

            return View("CreatePerson", model);
        }

        [Authorize]
        [HttpGet]
        public ActionResult GetPersonTypes()
        {
            var list = new List<SelectDropdownModel>();

            list.Add(new SelectDropdownModel
            {
                Id = PersonTypeConstants.Courier,
                Text = PersonTypeConstants.Courier
            }); 

            list.Add(new SelectDropdownModel
            {
                Id = PersonTypeConstants.Operator,
                Text = PersonTypeConstants.Operator
            });

            return new JsonResult
            {
                Data = list.Select(x => new { id = x.Id, text = x.Text }),
                JsonRequestBehavior = JsonRequestBehavior.AllowGet,
                ContentType = "application/json"
            };
        }

        [Authorize]
        [HttpPost]
        public ActionResult CreateProfile(PersonModel model)
        {
            _personService.AddPerson(model, User.Identity.Name);

            return RedirectToAction("Index");
        }
        
        [Authorize]
        [HttpPost]
        public ActionResult EditProfile(PersonModel model)
        {
            _personService.EditPerson(model, User.Identity.Name);

            return RedirectToAction("Index");

        }

    }
}