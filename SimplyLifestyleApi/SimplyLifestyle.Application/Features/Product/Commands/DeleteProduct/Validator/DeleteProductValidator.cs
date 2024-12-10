using FluentValidation;

namespace SimplyLifestyle.Application;

public class DeleteProductValidator : AbstractValidator<DeleteProductModel>, IRequestModelValidator
{
    public DeleteProductValidator()
    {
        RuleFor(model => model.Name)
            .NotNull()
            .NotEmpty();
    }
}
