using Common.Web;
using CustomerManagement.Application;
using CustomerManagement.Application.Customers.Commands.Create;
using Microsoft.AspNetCore.Mvc;

namespace CustomerManagement.Web.Features;

public class CustomersController : ApiController
{
    [HttpGet]
    public async Task<ActionResult<IEnumerable<CustomerResponse>>> Get([FromRoute] GetAllCustomersQuery query)
        => await Send(query);

    [HttpPost]
    public async Task<ActionResult<CreateCustomerResponse>> Create(CreateCustomerCommand command)
        => await Send(command);
}
