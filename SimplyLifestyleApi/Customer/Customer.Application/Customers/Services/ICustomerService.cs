using Common.Application.Contracts;

namespace CustomerManagement.Application.Customers.Services;

public interface ICustomerService : IApplicationService
{
    Task<Guid> GetOrCreateCustomerId(string firstName, string lastName, CancellationToken cancellationToken = default);
}
