using SimplyLifestyle.Utils;

namespace SimplyLifestyle.Application;

public class DeleteProductCommand :
    DeleteProductModel,
    ICommand<OperationResult<DeleteProductOutputModel>>,
    IModelValidatorDescriptor
{
    public Guid RequestId { get; } = Guid.NewGuid();

    Type IModelValidatorDescriptor.ValidatorType { get; } = typeof(DeleteProductValidator);
}
