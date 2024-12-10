using SimplyLifestyle.Domain;
using SimplyLifestyle.Utils;

namespace SimplyLifestyle.Application;

public class ProductService : IProductService
{
    private readonly IProductRepository _productRepository;

    public ProductService(IProductRepository productRepository)
    {
        _productRepository = productRepository;
    }

    public async Task<OperationResult<IEnumerable<Product>>> GetAllProductsAsync(CancellationToken cancellationToken = default)
    {
        var products = await _productRepository.FindAllAsync(cancellationToken);

        return OperationResult<IEnumerable<Product>>.Success(products);
    }

    public async Task<OperationResult<Product>> GetProductByIdAsync(Guid id, CancellationToken cancellationToken = default)
    {
        var product = await _productRepository.FindByIdAsync(id, cancellationToken);

        if(product == null)
            return OperationResult<Product>.Failure(new ResultError("", ResultErrorType.NotFound, $"Product with Id={id} not found"));

        return OperationResult<Product>.Success(product);
    }

    public async Task<OperationResult<Product>> GetProductByNameAsync(string name, CancellationToken cancellationToken = default)
    {
        var product = await _productRepository.FindByNameAsync(name, cancellationToken);

        if (product == null)
            return OperationResult<Product>.Failure(new ResultError("", ResultErrorType.NotFound, $"Product with name={name} not found"));

        return OperationResult<Product>.Success(product);
    }

    public async Task<OperationResult> AddProductAsync(Product product, CancellationToken cancellationToken = default)
    {
        await _productRepository.AddAsync(product);

        return OperationResult.Success();
    }

    public async Task<OperationResult> RemoveProductAsync(Product product, CancellationToken cancellationToken = default)
    {
        await _productRepository.RemoveAsync(product);

        return OperationResult.Success();
    }
}