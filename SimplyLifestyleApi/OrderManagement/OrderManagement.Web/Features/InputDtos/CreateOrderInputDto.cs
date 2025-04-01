using OrderManagement.Application;

namespace Orders.Web.Features.InputDtos;

public record CreateOrderInputDto(string CustomerFirstName, string CustomerLastName, DateTime OrderDate, int Status, List<OrderItemModel> OrderItems)
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