using CustomerManagement.Application.Customers.Commands.Common;
using CustomerManagement.Domain;
using CustomerManagement.Domain.Repositories;
using MediatR;

namespace CustomerManagement.Application.Customers.Commands.Create;

public class CreateCustomerCommand : CustomerCommand, IRequest<CreateCustomerResponse>
{
    public class CreateCustomerCommandHandler : IRequestHandler<CreateCustomerCommand, CreateCustomerResponse>
    {
        private readonly ICustomerDomainRepository _customerRepository;
        private readonly ICustomerFactory _customerFactory;

        public CreateCustomerCommandHandler(
            ICustomerDomainRepository customerRepository,
            ICustomerFactory customerFactory)
        {
            _customerRepository = customerRepository;
            _customerFactory = customerFactory;
        }

        public async Task<CreateCustomerResponse> Handle(
            CreateCustomerCommand request,
            CancellationToken cancellationToken)
        {
            var customer = _customerFactory
                .WithFirstName(request.FirstName)
                .WithLastName(request.LastName)
                .Build();

            await _customerRepository.Save(customer, cancellationToken);

            return new(customer.Id);
        }
    }
}
