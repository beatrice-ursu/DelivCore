using System.Collections.Generic;
using DelivCore.Models.Orders;

namespace DelivCore.BusinessLayer.DeliveryOfferService
{
    public interface IDeliveryOfferService
    {
        IList<DeliveryOfferModel> GetAllById(int id);
    }
}