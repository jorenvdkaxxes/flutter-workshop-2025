using OrderManagement.Application;
using OrderManagement.Application.Contracts.Orders;

namespace Orders.Web.Features.InputDtos;

public record CreateOrderInputDto(string CustomerFirstName, string CustomerLastName,
    DateTime OrderDate, int Status, List<OrderItemModel> OrderItems)
{
    public CreateOrderModel ToCreateOrderModel()
        => new(CustomerFirstName, CustomerLastName, OrderDate, Status, OrderItems);
}