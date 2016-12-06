using AutoMapper;
using DelivCore.Infrastructure.Automapper.Profiles;

namespace DelivCore.Infrastructure.Automapper
{
    public class AutomapperBootstrapper
    {
        public static MapperConfiguration GetConfiguration()
        {
            return new MapperConfiguration(cfg =>
            {
                //profiles
                cfg.AddProfile<PersonProfile>();
            });
        }
    }
}