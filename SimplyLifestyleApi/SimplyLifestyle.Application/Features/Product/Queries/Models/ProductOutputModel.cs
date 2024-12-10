namespace SimplyLifestyle.Application;

public class ProductOutputModel
{
    public Guid Id { get; set; }

    public string Name { get; set; } = default!;

    public float Price { get; set; }

    public int Stock { get; set; }

    public bool IsConfigurable { get; set; }

    public IEnumerable<string> Images { get; set; } = Enumerable.Empty<string>();

    public bool IsSuccess => true;
}
