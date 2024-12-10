using SimplyLifestyle.Utils;

namespace SimplyLifestyle.Domain;

public interface IProductService : IDomainService
{
    Task<OperationResult<IEnumerable<Product>>> GetAllProductsAsync(CancellationToken cancellationToken = default);

    Task<OperationResult<Product>> GetProductByIdAsync(Guid id, CancellationToken cancellationToken = default);
    
    Task<OperationResult<Product>> GetProductByNameAsync(string name, CancellationToken cancellationToken = default);

    Task<OperationResult> AddProductAsync(Product product, CancellationToken cancellationToken = default);

    Task<OperationResult> RemoveProductAsync(Product product, CancellationToken cancellationToken = default);
}
