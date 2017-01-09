using DelivCore.DataLayer.DbContext;
using DelivCore.DataLayer.Entities;
using DelivCore.DataLayer.Repositories.GenericRepository;

namespace DelivCore.DataLayer.Repositories.OrderOfferRepository
{
    public class OrderOfferRepository: GenericRepository<OrderOffer>, IOrderOfferRepository
    {
        public OrderOfferRepository(DelivCoreDbContext context) : base(context)
        {
        }
    }
}