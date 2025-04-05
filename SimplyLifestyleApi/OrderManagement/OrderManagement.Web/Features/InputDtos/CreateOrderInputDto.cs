using OrderManagement.Application;
using OrderManagement.Application.Contracts.Orders;

namespace Orders.Web.Features.InputDtos;

public record CreateOrderInputDto(string CustomerFirstName, string CustomerLastName,
    DateTime DeliveryDate, int Status, List<OrderItemModel> OrderItems)
{
    public CreateOrderModel ToCreateOrderModel()
        => new(CustomerFirstName, CustomerLastName, DeliveryDate, Status, OrderItems);
}