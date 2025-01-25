using FluentValidation;

namespace ProductCatalog.Application;

public class UpdateProductCommandValidator : AbstractValidator<ProductCommand>
{
    public UpdateProductCommandValidator() 
        => Include(new ProductCommandValidator());
}