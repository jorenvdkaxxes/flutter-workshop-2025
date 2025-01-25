namespace ProductCatalog.Domain;

internal class ProductFactory : IProductFactory
{
    private string productName = default!;
    private string productDescription = default!;
    private ProductType productType = default!;
    private Price productPrice = default!;

    private bool isNameSet;
    private bool isDescriptionSet;
    private bool isProductTypeSet;
    private bool isPriceSet;

    public IProductFactory WithName(string name)
    {
        productName = name;
        isNameSet = true;

        return this;
    }

    public IProductFactory WithDescription(string description)
    {
        productDescription = description;
        isDescriptionSet = true;

        return this;
    }

    public IProductFactory WithProductType(ProductType productType)
    {
        this.productType = productType;
        isProductTypeSet = true;

        return this;
    }

    public IProductFactory WithPrice(decimal price, string unit)
    {
        productPrice = new Price(price, unit);
        isPriceSet = true;

        return this;
    }

    public Product Build()
    {
        if (!isNameSet || !isDescriptionSet || !isProductTypeSet || !isPriceSet)
            throw new InvalidOperationException("Name, description, product type, price, and weight must have a value.");

        return new Product(
            productName,
            productDescription,
            productType,
            productPrice);
    }
}