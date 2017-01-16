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
            entities = entities.ToList();

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
        public IList<UserModel> GetAllUsersFromDB()
        {
            var entities = _personRepository.GetAll();
            var users = entities.Select(x => _mapper.Map<UserModel>(x)).ToList();

            return users;
        }
    }
}