using CustomerManagement.Domain.Models.Customers;

namespace CustomerManagement.Domain;

internal class CustomerFactory : ICustomerFactory
{
    private string _firstName = default!;
    private string _lastName = default!;

    private bool _isFirstNameSet;
    private bool _isLastNameSet;

    public ICustomerFactory WithFirstName(string firstName)
    {
        _firstName = firstName;
        _isFirstNameSet = true;

        return this;
    }

    public ICustomerFactory WithLastName(string lastName)
    {
        _lastName = lastName;
        _isLastNameSet = true;

        return this;
    }

    public Customer Build()
    {
        if (!_isFirstNameSet || !_isLastNameSet)
            throw new InvalidOperationException("First name and last name must have a value.");

        return new Customer(_firstName, _lastName);
    }
}