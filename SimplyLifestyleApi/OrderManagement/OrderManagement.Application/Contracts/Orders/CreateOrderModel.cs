namespace OrderManagement.Application.Contracts.Orders;

public record CreateOrderModel(string CustomerFirstName, string CustomerLastName,
    DateTimeOffset DeliveryDate, int Status, List<OrderItemModel> OrderItems)
{
    public CreateOrderCommand ToCommand(Guid customerId)
        => new()
        {
            CustomerId = customerId,
            DeliveryDate = DeliveryDate,
            Status = Status,
            OrderItems = OrderItems
        };
}