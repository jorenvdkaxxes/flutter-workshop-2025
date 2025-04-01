using Common.Domain;
using CustomerManagement.Domain.Models.Customers;

namespace CustomerManagement.Domain.Repositories;

public interface ICustomerDomainRepository : IDomainRepository<Customer>
{
    Task<Customer> FindByIdAsync(Guid id, CancellationToken cancellationToken = default);
}
