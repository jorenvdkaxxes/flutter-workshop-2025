namespace OrderManagement.Application.Contracts.Orders;

public record CreateOrderModel(string CustomerFirstName, string CustomerLastName,
    DateTime OrderDate, int Status, List<OrderItemModel> OrderItems)
{
    public CreateOrderCommand ToCommand(Guid customerId)
        => new()
        {
            CustomerId = customerId,
            OrderDate = OrderDate,
            Status = Status,
            OrderItems = OrderItems
        };
}