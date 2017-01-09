namespace DelivCore.BusinessLayer.OrderOfferService
{
    public interface IOrderOfferService
    {
        void CreateOrderOffer(int OrderId, string OrderDescription);
    }
}