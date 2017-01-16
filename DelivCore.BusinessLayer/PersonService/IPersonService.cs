using System.Collections.Generic;
using DelivCore.Models.Person;
using DelivCore.Models.Persons;

namespace DelivCore.BusinessLayer.PersonService
{
    public interface IPersonService
    {
        //Do logic here, like defaulting stuff, updating other stuff bla and return Models only
        IList<FakePerson> GetFakePersons();
        IList<FakerPerson> GetFakerPersons();
        IList<CourierModel> GetCouriers();
        IList<UserModel> GetAllUsersFromDB();
    }
}