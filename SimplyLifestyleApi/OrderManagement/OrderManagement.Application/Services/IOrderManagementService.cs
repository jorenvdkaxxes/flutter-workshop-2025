using Common.Application.Contracts;
using OrderManagement.Application.Contracts.Orders;

namespace OrderManagement.Application.Services;

public interface IOrderManagementService : IApplicationService
{
    Task<CreateOrderResponse> CreateOrder(CreateOrderModel createOrderModel);
}
