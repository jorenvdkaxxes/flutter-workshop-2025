namespace SimplyLifestyle.Application;

public class DeleteProductModel : IRequestModel
{
    public string Name { get; set; } = default!;
}
