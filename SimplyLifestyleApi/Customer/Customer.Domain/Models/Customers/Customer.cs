using Common.Domain;

namespace CustomerManagement.Domain.Models.Customers;

public class Customer : Entity, IAggregateRoot
{
    public Customer(string firstName, string lastName)
    {
        FirstName = firstName;
        LastName = lastName;
    }

    public string FirstName { get; private set; }
    public string LastName { get; private set; }

    public Customer UpdateFirstName(string firstName)
    {
        FirstName = firstName;

        return this;
    }

    public Customer UpdateLastName(string lastName)
    {
        LastName = lastName;

        return this;
    }
}
