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
    public class MessageProfile: Profile
    {
        public MessageProfile()
        {
            CreateMap<Message, MessageModel>();
            CreateMap<MessageModel, Message>();
        }
    }
}
