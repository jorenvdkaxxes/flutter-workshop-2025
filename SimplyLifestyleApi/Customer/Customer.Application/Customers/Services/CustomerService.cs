using CustomerManagement.Application.Customers.Commands.Create;
using CustomerManagement.Application.Customers.Queries;
using MediatR;

namespace CustomerManagement.Application.Customers.Services;

public class CustomerService : ICustomerService
{
    private readonly ICustomerQueryRepository _customerQueryRepository;
    private readonly IMediator _mediator;

    public CustomerService(ICustomerQueryRepository customerQueryRepository, IMediator mediator)
    {
        _customerQueryRepository = customerQueryRepository;
        _mediator = mediator;
    }

    public async Task<Guid> GetOrCreateCustomerId(string firstName, string lastName, CancellationToken cancellationToken = default)
    {
        var customer = await _customerQueryRepository.GetWithFirstAndLastNameAsync(firstName, lastName);

        if (customer is not null)
            return customer.Id;

        var createCustomerCommand = new CreateCustomerCommand
        {
            FirstName = firstName,
            LastName = lastName
        };

        var response = await _mediator.Send(createCustomerCommand);

        return response.Id;
    }
}
