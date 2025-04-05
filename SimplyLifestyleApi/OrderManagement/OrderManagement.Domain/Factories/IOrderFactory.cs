using Common.Domain;

namespace OrderManagement.Domain;

public interface IOrderFactory : IFactory<Order>
{
    IOrderFactory WithCustomerId(Guid customerId);
    IOrderFactory WithDeliveryDate(DateTimeOffset orderDate);
    Order Build();
}
