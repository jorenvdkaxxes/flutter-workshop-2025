using Common.Application;
using CustomerManagement.Domain.Models.Customers;

namespace CustomerManagement.Application.Customers.Queries;

public interface ICustomerQueryRepository : IQueryRepository<Customer>
{
    Task<IEnumerable<CustomerResponse>> GetAllAsync(CancellationToken cancellationToken = default);
}
