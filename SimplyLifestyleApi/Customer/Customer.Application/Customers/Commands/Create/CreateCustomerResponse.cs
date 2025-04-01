namespace CustomerManagement.Application.Customers.Commands.Create;

public class CreateCustomerResponse
{
    internal CreateCustomerResponse(Guid id) => Id = id;

    public Guid Id { get; }
}
