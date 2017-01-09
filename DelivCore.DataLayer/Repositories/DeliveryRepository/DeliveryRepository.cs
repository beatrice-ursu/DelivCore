using DelivCore.DataLayer.DbContext;
using DelivCore.DataLayer.Entities;
using DelivCore.DataLayer.Repositories.GenericRepository;

namespace DelivCore.DataLayer.Repositories.DeliveryRepository
{
    public class DeliveryRepository: GenericRepository<Delivery>, IDeliveryRepository
    {
        public DeliveryRepository(DelivCoreDbContext context) : base(context)
        {
        }
    }
}