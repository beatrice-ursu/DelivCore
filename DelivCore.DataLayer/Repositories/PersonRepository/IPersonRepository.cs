using DelivCore.DataLayer.Entities;
using DelivCore.DataLayer.Repositories.GenericRepository;

namespace DelivCore.DataLayer.Repositories.PersonRepository
{
    public interface IPersonRepository : IGenericRepository<Person>
    {
        //Do stuff Database ONLY related
    }
}