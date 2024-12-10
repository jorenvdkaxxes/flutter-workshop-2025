using SimplyLifestyle.Utils;

namespace SimplyLifestyle.Domain;

internal class ProductFactory : Validatable, IProductFactory
{
    private string _name = default!;
    private float _price;
    private int _stock;
    private bool _isConfigurable;
    private IEnumerable<string> _images = new List<string>();

    private readonly IProductService _productService;

    public ProductFactory(IProductService productService)
    {
        _productService = productService;
    }

    public IProductFactory WithName(string name)
    {
        AsyncHelper.RunSync(() => CheckIfNameExistsOrAddErrorAsync(name));

        _name = name;

        return this;
    }

    public IProductFactory WithPrice(float price)
    {
        _price = price;

        return this;
    }

    public IProductFactory WithStock(int stock)
    {
        _stock = stock;

        return this;
    }

    public IProductFactory WithIsConfigurable(bool isConfigurable)
    {
        _isConfigurable = isConfigurable;

        return this;
    }

    public IProductFactory WithImages(params string[] images)
    {
        _images = images;

        return this;
    }

    public OperationResult<Product> Build()
    {
        if (!IsValidState)
            return OperationResult<Product>.Failure(Errors);

        var product = new Product(new ProductId(Guid.NewGuid()), _name, _price, _stock, _isConfigurable, _images);

        return OperationResult<Product>.Success(product);
    }

    public Task<OperationResult<Product>> BuildAsync()
    {
        throw new NotImplementedException();
    }

    private async Task CheckIfNameExistsOrAddErrorAsync(string name)
    {
        var result = await _productService.GetProductByNameAsync(name);
        if (result.IsSuccess)
        {
            AddError(new ResultError("InvalidData", ResultErrorType.ObjectExists, "Name exists"));
        }
    }
}
