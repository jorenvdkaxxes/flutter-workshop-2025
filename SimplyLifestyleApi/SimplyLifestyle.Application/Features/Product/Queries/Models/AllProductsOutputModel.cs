using SimplyLifestyle.Application;

namespace SimplyLifestyle.Domain;

public class AllProductsOutputModel : IOutputModel
{
    public AllProductsOutputModel() { }

    public IEnumerable<ProductOutputModel> Products { get; set; } = Enumerable.Empty<ProductOutputModel>();

    public virtual bool IsSuccess => true;
}
