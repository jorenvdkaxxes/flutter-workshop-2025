namespace SimplyLifestyle.Domain;

public class ProductCategory: AggregateRoot<ProductCategoryId>
{
    public ProductCategory(ProductCategoryId id,
        string name)
    {
        Id = id;
        Name = name;
        Products = new List<Product>();
    }

    public string Name { get; set; }

    public IEnumerable<Product> Products { get; set; }
}
