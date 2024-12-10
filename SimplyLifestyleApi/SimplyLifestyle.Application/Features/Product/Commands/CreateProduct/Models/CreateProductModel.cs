namespace SimplyLifestyle.Application;

public class CreateProductModel : IRequestModel
{
    public string Name { get; set; } = default!;

    public float Price { get; set; }

    public int Stock { get; set; }

    public bool IsConfigurable { get; set; }
}