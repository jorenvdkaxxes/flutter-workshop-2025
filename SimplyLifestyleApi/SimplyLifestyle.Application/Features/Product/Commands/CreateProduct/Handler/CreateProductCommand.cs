using SimplyLifestyle.Utils;

namespace SimplyLifestyle.Application;

public class CreateProductCommand :
    CreateProductModel,
    ICommand<OperationResult<CreateProductOutputModel>>,
    IModelValidatorDescriptor
{
    public Guid RequestId { get; } = Guid.NewGuid();

    Type IModelValidatorDescriptor.ValidatorType { get; } = typeof(CreateProductValidator);
}
