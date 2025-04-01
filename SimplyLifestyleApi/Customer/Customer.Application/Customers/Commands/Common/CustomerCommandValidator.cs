using FluentValidation;

namespace CustomerManagement.Application.Customers.Commands.Common;

public class CustomerCommandValidator : AbstractValidator<CustomerCommand>
{
    public CustomerCommandValidator()
    {
        RuleFor(b => b.FirstName)
            .NotEmpty();

        RuleFor(b => b.LastName)
            .NotEmpty();
    }
}
