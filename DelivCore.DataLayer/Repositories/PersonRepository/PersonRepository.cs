using DelivCore.DataLayer.DbContext;
using DelivCore.DataLayer.Entities;
using DelivCore.DataLayer.Repositories.GenericRepository;

namespace DelivCore.DataLayer.Repositories.PersonRepository
{
    public class PersonRepository : GenericRepository<Person>, IPersonRepository
    {
        //Do stuff Database ONLY related
        public PersonRepository(DelivCoreDbContext context) : base(context)
        {
        }
    }
}