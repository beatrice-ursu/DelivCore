using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using DelivCore.DataLayer.Entities;
using DelivCore.Models.Persons;

namespace DelivCore.Infrastructure.Automapper.Profiles
{
    class ClientProfile: Profile
    {
        public ClientProfile()
        {
            CreateMap<Client, ClientModel>()
                .ForMember(dest => dest.Orders, a => a.Ignore());
            CreateMap<ClientModel, Client>();
        }
    }
}
