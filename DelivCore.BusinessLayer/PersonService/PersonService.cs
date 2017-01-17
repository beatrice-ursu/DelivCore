using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using DelivCore.DataLayer.Entities;
using DelivCore.DataLayer.Repositories.PersonRepository;
using DelivCore.Models.Persons;
using DelivCore.DataLayer.Repositories.DeliveryRepository;
using System;
using DelivCore.Models.Core;

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
        public IList<PersonModel> GetAllPersonsFromDB()
        {
            var entities = _personRepository.GetAll();
            var persons = entities.Select(x => _mapper.Map<PersonModel>(x)).ToList();

            return persons;
        }

        public void AddPerson(PersonModel person, string currentUser)
        {
            person.Defaults(currentUser);
            var personEntity = _mapper.Map<Person>(person);

            _personRepository.Insert(personEntity);
            _personRepository.SaveChanges();
        }

        public PersonModel GetById(int id)
        {
            var entity = _personRepository.GetById(id);
            var person = _mapper.Map<PersonModel>(entity);

            return person;
        }

        public void EditPerson(PersonModel person, string currentUser)
        {
            var entity = _personRepository.GetById(person.Id);

            entity.FirstName = person.FirstName;
            entity.LastName = person.LastName;
            entity.Username = person.Username;
            entity.PersonType = person.PersonType;
            entity.UpdatedOn = DateTime.Now;
            entity.UpdatedBy = currentUser;

            _personRepository.Update(entity);
            _personRepository.SaveChanges();
        }
    }
}