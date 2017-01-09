using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using DelivCore.DataLayer.Repositories.ClientRepository;
using DelivCore.Models.Orders;
using DelivCore.Models.Persons;

namespace DelivCore.BusinessLayer.ClientService
{
    public class ClientService : IClientService
    {
        private readonly IClientRepository _clientRepository;
        private readonly IMapper _mapper;

        public ClientService(IClientRepository clientRepository, IMapper mapper)
        {
            _clientRepository = clientRepository;
            _mapper = mapper;
        }


        public IList<ClientModel> GetAll()
        {
            var clientsEntities = _clientRepository.GetAll();
            var clients = clientsEntities.Select(x => _mapper.Map<ClientModel>(x)).ToList();
            return clients;
        }
    }
}
