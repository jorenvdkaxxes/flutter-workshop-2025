using Microsoft.Extensions.Logging;
using SimplyLifestyle.Domain;
using SimplyLifestyle.Utils;

namespace SimplyLifestyle.Application;

public class DeleteProductCommandHandler : CommandHandler<DeleteProductCommand, OperationResult<DeleteProductOutputModel>, DeleteProductOutputModel>
{
    private readonly IProductService _productService;

    public DeleteProductCommandHandler(
        IProductService productService,
        ILogger<CommandHandler<DeleteProductCommand, OperationResult<DeleteProductOutputModel>, DeleteProductOutputModel>> logger)
        : base(logger)
    {
        _productService = productService;
    }

    protected override async Task<OperationResult<DeleteProductOutputModel>> HandleCore(DeleteProductCommand command, CancellationToken cancellationToken)
    {
        var foundProduct = await _productService.GetProductByNameAsync(command.Name, cancellationToken);
        if (!foundProduct.IsSuccess)
            return OperationResult<DeleteProductOutputModel>.Failure(ProductErrors.NoProductFound(command.Name));

        await _productService.RemoveProductAsync(foundProduct, cancellationToken);

        return OperationResult<DeleteProductOutputModel>.Success(new DeleteProductOutputModel());
    }
}