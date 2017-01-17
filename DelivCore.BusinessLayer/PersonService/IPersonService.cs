using System.Collections.Generic;
using DelivCore.Models.Persons;

namespace DelivCore.BusinessLayer.PersonService
{
    public interface IPersonService
    {
        IList<CourierModel> GetCouriers();
        IList<PersonModel> GetAllPersonsFromDB();
        void AddPerson(PersonModel person, string currentUser);
        PersonModel GetById(int id);
        void EditPerson(PersonModel person, string currentUser);
    }
}