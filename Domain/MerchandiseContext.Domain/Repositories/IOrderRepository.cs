namespace Domain.MerchandiseContext
{
    public interface IOrderRepository
    {
        Order CreateOrder(Order order);
    }
}