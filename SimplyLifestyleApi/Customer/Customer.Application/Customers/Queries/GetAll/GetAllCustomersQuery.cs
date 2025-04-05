using Common.Application;
using CustomerManagement.Application.Customers.Queries;
using MediatR;

namespace CustomerManagement.Application;

public class GetAllCustomersQuery : EntityCommand, IRequest<IEnumerable<CustomerResponse>>
{
    public class GetAllProductsQueryHandler : IRequestHandler<GetAllCustomersQuery, IEnumerable<CustomerResponse>>
    {
        private readonly ICustomerQueryRepository _customerQueryRepository;

        public GetAllProductsQueryHandler(ICustomerQueryRepository customerRepository)
            => _customerQueryRepository = customerRepository;

        public async Task<IEnumerable<CustomerResponse>> Handle(
            GetAllCustomersQuery request,
            CancellationToken cancellationToken)
            => await _customerQueryRepository.GetAllAsync(
                cancellationToken);
    }
}
