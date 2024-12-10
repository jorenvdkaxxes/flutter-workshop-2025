using Microsoft.Extensions.Logging;
using SimplyLifestyle.Domain;
using SimplyLifestyle.Utils;

namespace SimplyLifestyle.Application;

public class CreateProductCommandHandler : CommandHandler<CreateProductCommand, OperationResult<CreateProductOutputModel>, CreateProductOutputModel>
{
    private readonly IProductFactory _productFactory;
    private readonly IProductService _productService;

    public CreateProductCommandHandler(
        IProductFactory productFactory,
        IProductService productService,
        ILogger<CommandHandler<CreateProductCommand, OperationResult<CreateProductOutputModel>, CreateProductOutputModel>> logger)
        : base(logger)
    {
        _productFactory = productFactory;
        _productService = productService;
    }

    protected override async Task<OperationResult<CreateProductOutputModel>> HandleCore(CreateProductCommand command, CancellationToken cancellationToken)
    {
        var foundProduct = await _productService.GetProductByNameAsync(command.Name, cancellationToken);
        if (foundProduct.IsSuccess)
            return OperationResult<CreateProductOutputModel>.Failure(ProductErrors.ProductAlreadyExists(command.Name));

        var newProduct = _productFactory
                            .WithName(command.Name)
                            .WithPrice(command.Price)
                            .WithStock(command.Stock)
                            .WithIsConfigurable(command.IsConfigurable)
                            .Build();

        await _productService.AddProductAsync(newProduct, cancellationToken);

        return OperationResult<CreateProductOutputModel>.Success(new CreateProductOutputModel());
    }
}
