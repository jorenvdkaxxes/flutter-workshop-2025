using Microsoft.Extensions.Logging;
using SimplyLifestyle.Domain;
using SimplyLifestyle.Utils;

namespace SimplyLifestyle.Application;

public class AllProductsQueryHandler : QueryHandler<AllProductsQuery, OperationResult<AllProductsOutputModel>, AllProductsOutputModel>
{
    private readonly IProductService _productService;

    public AllProductsQueryHandler(
        IProductService productService,
        ILogger<QueryHandler<AllProductsQuery, OperationResult<AllProductsOutputModel>, AllProductsOutputModel>> logger)
            : base(logger)
    {
        _productService = productService;
    }

    protected override async Task<OperationResult<AllProductsOutputModel>> HandleCore(AllProductsQuery query, CancellationToken cancellationToken)
    {
        var products = await _productService.GetAllProductsAsync(cancellationToken);
        var outputModels = products.Data.ToOutputModels();

        return OperationResult<AllProductsOutputModel>
                .Success(new AllProductsOutputModel { Products = outputModels });
    }
}