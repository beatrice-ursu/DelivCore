using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;
using DelivCore.BusinessLayer.PersonService;

namespace DelivCore.API.Controllers
{
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class ValuesController : ApiController
    {
        private readonly IPersonService _personService;
        public ValuesController(IPersonService personService)
        {
            _personService = personService;
        }

        [HttpGet]
        [Route("ping")]
        public IHttpActionResult NotSecured()
        {
            var test = _personService.GetFakePersons();
            return Ok(test);
        }

        [Authorize]
        [HttpGet]
        [Route("secured/ping")]

        public IHttpActionResult Secured()
        {
            var test = _personService.GetFakePersons();
            return this.Ok("All good. You only get this message if you are authenticated.");
        }
    }
}
