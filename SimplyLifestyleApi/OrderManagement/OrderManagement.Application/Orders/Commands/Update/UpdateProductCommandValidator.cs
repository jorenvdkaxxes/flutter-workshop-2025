using FluentValidation;

namespace OrderManagement.Application;

public class UpdateProductCommandValidator : AbstractValidator<OrderCommand>
{
    public UpdateProductCommandValidator() 
        => Include(new OrderCommandValidator());
}