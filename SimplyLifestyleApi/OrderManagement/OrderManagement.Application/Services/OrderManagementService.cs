
using CustomerManagement.Application.Customers.Services;
using OrderManagement.Application.Contracts.Orders;
using MediatR;

namespace OrderManagement.Application.Services;

internal class OrderManagementService : IOrderManagementService
{
    private readonly ICustomerService _customerService;
    private readonly IMediator _mediator;

    public OrderManagementService(ICustomerService customerService, IMediator mediator)
    {
        _customerService = customerService;
        _mediator = mediator;
    }

    public async Task<CreateOrderResponse> CreateOrder(CreateOrderModel createOrderModel)
    {
        var customerId = await _customerService.GetOrCreateCustomerId(createOrderModel.CustomerFirstName, createOrderModel.CustomerLastName);

        var createOrderCommand = createOrderModel.ToCommand(customerId);

        var result = await _mediator.Send(createOrderCommand);

        return result;
    }
}
