using AutoMapper;
using DelivCore.DataLayer.Entities;
using DelivCore.Models.Person;

namespace DelivCore.Infrastructure.Automapper.Profiles
{
    public class PersonProfile : Profile
    {
        public PersonProfile()
        {
            CreateMap<Person, FakePerson>()
                .ForMember(dest => dest.FullName, a => a.MapFrom(src => src.LastName + " " + src.FirstName));
            CreateMap<Person, FakerPerson>();

            CreateMap<FakerPerson, Person>();
            CreateMap<FakePerson, Person>();
        }
    }
}