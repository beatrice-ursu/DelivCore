using DelivCore.DataLayer.DbContext;
using DelivCore.DataLayer.Entities;
using DelivCore.DataLayer.Repositories.GenericRepository;

namespace DelivCore.DataLayer.Repositories.DeliveryOfferRepository
{
    public class DeliveryOfferRepository: GenericRepository<DeliveryOffer>, IDeliveryOfferRepository
    {
        public DeliveryOfferRepository(DelivCoreDbContext context) : base(context)
        {
        }
    }
}
