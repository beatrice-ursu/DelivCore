using DelivCore.DataLayer.DbContext;
using DelivCore.DataLayer.Entities;
using DelivCore.DataLayer.Repositories.GenericRepository;

namespace DelivCore.DataLayer.Repositories.ClientRepository
{
    public class ClientRepository: GenericRepository<Client>, IClientRepository
    {
        public ClientRepository(DelivCoreDbContext context) : base(context)
        {
        }
    }
}
