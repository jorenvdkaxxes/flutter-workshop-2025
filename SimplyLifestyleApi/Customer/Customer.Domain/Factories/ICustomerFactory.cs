using Common.Domain;
using CustomerManagement.Domain.Models.Customers;

namespace CustomerManagement.Domain;

public interface ICustomerFactory : IFactory<Customer>
{
    ICustomerFactory WithFirstName(string name);

    ICustomerFactory WithLastName(string name);
}