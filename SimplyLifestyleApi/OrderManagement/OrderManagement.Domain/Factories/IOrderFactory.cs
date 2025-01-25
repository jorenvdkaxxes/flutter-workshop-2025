using Common.Domain;

namespace OrderManagement.Domain;

public interface IOrderFactory : IFactory<Order>
{
    IOrderFactory WithCustomerId(Guid customerId);
    IOrderFactory WithOrderDate(DateTime orderDate);
    Order Build();
}
