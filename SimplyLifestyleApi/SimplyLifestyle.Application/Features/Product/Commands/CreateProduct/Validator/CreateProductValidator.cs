using FluentValidation;

namespace SimplyLifestyle.Application;

public class CreateProductValidator : AbstractValidator<CreateProductModel>, IRequestModelValidator
{
    public CreateProductValidator()
    {
        RuleFor(model => model.Name)
            .NotNull()
            .NotEmpty();

        RuleFor(model => model.Price)
            .GreaterThan(0);

        RuleFor(model => model.Stock)
            .GreaterThanOrEqualTo(0);
    }
}