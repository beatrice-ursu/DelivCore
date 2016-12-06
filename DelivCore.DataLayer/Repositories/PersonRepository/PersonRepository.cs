using DelivCore.DataLayer.Entities;
using DelivCore.DataLayer.Repositories.GenericRepository;

namespace DelivCore.DataLayer.Repositories.PersonRepository
{
    public class PersonRepository : GenericRepository<Person>, IPersonRepository
    {
        //Do stuff Database ONLY related
    }
}