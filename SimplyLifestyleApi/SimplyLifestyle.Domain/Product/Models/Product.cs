namespace SimplyLifestyle.Domain;

public class Product: Entity<ProductId>
{
    public Product(ProductId id,
        string name,
        float price,
        int stock,
        bool isConfigurable,
        params string[] images)
    {
        Id = id;
        Name = name;
        Price = price;
        Stock = stock;
        IsConfigurable = isConfigurable;
        Images = images;
    }

    public Product(ProductId id,
        string name,
        float price,
        int stock,
        bool isConfigurable,
        IEnumerable<string> images)
    {
        Id = id;
        Name = name;
        Price = price;
        Stock = stock;
        IsConfigurable = isConfigurable;
        Images = images;
    }

    public string Name { get; set; }

    public float Price { get; set; }

    public int Stock { get; set; }

    public bool IsConfigurable { get; set; }

    public IEnumerable<string> Images { get; set; }
}
