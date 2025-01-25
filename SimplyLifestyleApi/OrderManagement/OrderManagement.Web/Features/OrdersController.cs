using Common.Web;
using Microsoft.AspNetCore.Mvc;
using OrderManagement.Application;

namespace OrderManagement.Web;

public class OrdersController : ApiController
{
    [HttpGet]
    public async Task<ActionResult<IEnumerable<OrderResponse>>> Get([FromRoute] GetAllOrdersQuery query)
        => await Send(query);

    [HttpGet]
    [Route(Id)]
    public async Task<ActionResult<OrderResponse>> GetById([FromRoute] OrderDetailsQuery query)
        => await Send(query);

    [HttpPost]
    public async Task<ActionResult<CreateOrderResponse>> Create(CreateOrderCommand command)
        => await Send(command);

    [HttpPut]
    [Route(Id)]
    public async Task<ActionResult> Update(UpdateOrderCommand command)
        => await Send(command);
}