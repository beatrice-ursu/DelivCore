using System.Linq;
using DelivCore.DataLayer.DbContext;
using DelivCore.DataLayer.Entities;
using DelivCore.DataLayer.Repositories.GenericRepository;

namespace DelivCore.DataLayer.Repositories.OrderRepository
{
    public class OrderRepository:GenericRepository<Order>, IOrderRepository
    {
        public OrderRepository(DelivCoreDbContext context) : base(context)
        {
        }

        public override Order GetById(object id)
        {
            return DbSet.Include("Client").FirstOrDefault(x => x.Id == (int) id);
        }
    }
}