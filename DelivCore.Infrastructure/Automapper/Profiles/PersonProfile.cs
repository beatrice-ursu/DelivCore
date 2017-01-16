using AutoMapper;
using DelivCore.DataLayer.Entities;
using DelivCore.Models.Persons;

namespace DelivCore.Infrastructure.Automapper.Profiles
{
    public class PersonProfile : Profile
    {
        public PersonProfile()
        {
            CreateMap<Person, CourierModel>()
                .ForMember(dest => dest.Deliveries, a => a.Ignore()); ;
            CreateMap<CourierModel, Person>();
            CreateMap<Person, UserModel>();
            CreateMap<UserModel, Person>();
        }
    }
}