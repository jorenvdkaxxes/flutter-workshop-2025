using FluentValidation;

namespace ProductCatalog.Application;

public class CreateProductCommandValidator : AbstractValidator<CreateProductCommand>
{
    public CreateProductCommandValidator()
        => Include(new ProductCommandValidator());
}