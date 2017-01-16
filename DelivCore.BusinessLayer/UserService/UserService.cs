using Auth0.ManagementApi;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using DelivCore.DataLayer.Repositories.PersonRepository;
using DelivCore.Models.Persons;

namespace DelivCore.BusinessLayer.UserService
{
    public class UserService: IUserService
    {
        protected readonly IPersonRepository _personRepository;
        protected readonly IMapper _mapper;

        public UserService(IPersonRepository personRepository, IMapper mapper)
        {
            _personRepository = personRepository;
            _mapper = mapper;
        }
        protected ManagementApiClient GetApiClient()
        {
            return
                new ManagementApiClient(ConfigurationManager.AppSettings["auth0:ManagementAPIJWT"],
                    ConfigurationManager.AppSettings["auth0:Domain"]);
        }

        public async Task<List<string>> GetUserNames()
        {
            var client = GetApiClient();
            var users = await client.Users.GetAllAsync();

            return users.Select(x => x.FullName).ToList();
        }

        public async Task<List<UserDropdownModel>> GetUsersList()
        {
            var client = GetApiClient();
            var users = await client.Users.GetAllAsync();

            return users.Select(x => new UserDropdownModel { Id = x.FullName ?? string.Empty, Text = x.FullName ?? string.Empty}).ToList();
        }


    }
}
