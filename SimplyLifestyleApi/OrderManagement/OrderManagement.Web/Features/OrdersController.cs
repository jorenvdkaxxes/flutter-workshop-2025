using Common.Web;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using OrderManagement.Application;
using OrderManagement.Application.Services;
using Orders.Web.Features.InputDtos;

namespace OrderManagement.Web;

[Authorize]
public class OrdersController : ApiController
{
    private readonly IOrderManagementService _orderManagementService;

    public OrdersController(IOrderManagementService orderManagementService)
    {
        _orderManagementService = orderManagementService;
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
        return await _orderManagementService.CreateOrder(inputDto.ToCreateOrderModel());
    }

    [HttpPut]
    [Route(Id)]
    public async Task<ActionResult> Update(UpdateOrderCommand command)
        => await Send(command);
}