namespace SimplyLifestyle.Domain;

public interface IProductFactory : IFactory<Product>
{
    IProductFactory WithName(string name);

    IProductFactory WithPrice(float price);

    IProductFactory WithStock(int stock);

    IProductFactory WithIsConfigurable(bool isConfigurable);

    IProductFactory WithImages(params string[] images);
}
