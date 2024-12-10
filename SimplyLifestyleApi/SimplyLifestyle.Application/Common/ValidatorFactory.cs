using FluentValidation;
using System.Diagnostics.CodeAnalysis;

namespace SimplyLifestyle.Application;

[ExcludeFromCodeCoverage]
public static class ValidatorFactory
{
    public static TModelValidator Get<TModelValidator>()
        where TModelValidator : IRequestModelValidator, new()
            => new();

    public static IValidator Get(Type validatorType)
    {
        switch (validatorType)
        {
            case Type _ when validatorType == typeof(CreateProductValidator):
                return new CreateProductValidator();

            default:
                throw new NotImplementedException();
        }
    }
}
