using Common.Web;
using CustomerManagement.Application.Customers.Commands.Create;
using CustomerManagement.Application.Customers.Queries;
using Microsoft.AspNetCore.Mvc;
using OrderManagement.Application;
using Orders.Web.Features.InputDtos;

namespace OrderManagement.Web;

public class OrdersController : ApiController
{
    private readonly ICustomerQueryRepository _customerQueryRepository;

    public OrdersController(ICustomerQueryRepository customerQueryRepository)
    {
        _customerQueryRepository = customerQueryRepository;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<OrderResponse>>> Get([FromRoute] GetAllOrdersQuery query)
        => await Send(query);

    [HttpGet]
    [Route(Id)]
    public async Task<ActionResult<OrderResponse>> GetById([FromRoute] OrderDetailsQuery query)
        => await Send(query);

    [HttpPost]
    public async Task<ActionResult<CreateOrderResponse>> Create(CreateOrderInputDto inputDto)
    {
        var customerId = Guid.Empty;
        var customer = await _customerQueryRepository.GetWithFirstAndLastNameAsync(inputDto.CustomerFirstName, inputDto.CustomerLastName);

        if(customer is null)
        {
            var createCustomerCommand = new CreateCustomerCommand
            {
                FirstName = inputDto.CustomerFirstName,
                LastName = inputDto.CustomerLastName
            };

            var response = await SendCommand(createCustomerCommand);
            customerId = response.Id;
        }
        else
        {
            customerId = customer.Id;
        }

        var createOrderCommand = inputDto.ToCommand(customerId);

        var result = await Send(createOrderCommand);

        return result;
    }

    [HttpPut]
    [Route(Id)]
    public async Task<ActionResult> Update(UpdateOrderCommand command)
        => await Send(command);
}