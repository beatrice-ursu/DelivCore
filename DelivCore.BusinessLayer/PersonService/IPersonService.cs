using System.Collections.Generic;
using DelivCore.Models.Person;

namespace DelivCore.BusinessLayer.PersonService
{
    public interface IPersonService
    {
        //Do logic here, like defaulting stuff, updating other stuff bla and return Models only
        IList<FakePerson> GetFakePersons();
        IList<FakerPerson> GetFakerPersons();
    }
}