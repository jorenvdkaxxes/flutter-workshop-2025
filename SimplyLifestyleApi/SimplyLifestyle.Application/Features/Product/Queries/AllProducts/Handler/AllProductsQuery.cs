using SimplyLifestyle.Domain;
using SimplyLifestyle.Utils;

namespace SimplyLifestyle.Application;

public class AllProductsQuery : IQuery<OperationResult<AllProductsOutputModel>>
{
    public Guid RequestId { get; } = Guid.NewGuid();
}
