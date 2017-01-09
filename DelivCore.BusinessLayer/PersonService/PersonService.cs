using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using DelivCore.DataLayer.Entities;
using DelivCore.DataLayer.Repositories.PersonRepository;
using DelivCore.Models.Person;
using DelivCore.Models.Persons;
using DelivCore.DataLayer.Repositories.DeliveryRepository;

namespace DelivCore.BusinessLayer.PersonService
{
    public class PersonService : IPersonService
    {
        /*
         * Do logic here, like defaulting stuff, updating other stuff bla and return Models only
         * Turn Entities into Models using automapper
         * Only inject other repositories to grab data
         * Don't inject other Services
         */

        private readonly IMapper _mapper;
        private readonly IPersonRepository _personRepository;
        private readonly IDeliveryRepository _deliveryRepository;
        public PersonService(IMapper mapper, IPersonRepository personRepository, IDeliveryRepository deliveryRepository)
        {
            _mapper = mapper;
            _personRepository = personRepository;
            _deliveryRepository = deliveryRepository;
        }

        public IList<FakePerson> GetFakePersons()
        {
            var entities = _personRepository.GetAll();
            //IEnumerable doesent have .Add()
            entities = entities.ToList();
            //demonstrate automapper magic
            //((IList<Person>)entities).Add(new Person { Age = 21, LastName = "Urs", FirstName = "Rob" });
            //((IList<Person>)entities).Add(new Person { Age = 21, LastName = "Tom", FirstName = "Bea" });

            var models = entities.Select(x => _mapper.Map<FakePerson>(x)).ToList();
            models.Add(new FakePerson { Age = 21, FullName = "Ursu Robert Andrei" });
            models.Add(new FakePerson { Age = 22, FullName = "Toma Beatrice Ramona" });
            return models;
        }

        public IList<FakerPerson> GetFakerPersons()
        {
            var entities = _personRepository.GetAll();
            var models = entities.Select(x => _mapper.Map<FakerPerson>(x)).ToList();
            return models;
        }

        public IList<CourierModel> GetCouriers()
        {
            var couriersEntities = _personRepository.GetAll();
            var couriers = couriersEntities.Select(x => _mapper.Map<CourierModel>(x)).ToList();
            foreach(var item in couriers)
            {
                item.NoOfOrders = _deliveryRepository.GetAll().Where(x => x.Courier.Id == item.Id).ToList().Count;
            }
            return couriers;
        }
    }
}