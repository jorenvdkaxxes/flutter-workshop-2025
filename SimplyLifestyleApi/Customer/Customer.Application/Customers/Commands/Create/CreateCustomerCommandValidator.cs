using CustomerManagement.Application.Customers.Commands.Common;
using FluentValidation;

namespace CustomerManagement.Application.Customers.Commands.Create;

public class CreateCustomerCommandValidator : AbstractValidator<CreateCustomerCommand>
{
    public CreateCustomerCommandValidator()
        => Include(new CustomerCommandValidator());
}