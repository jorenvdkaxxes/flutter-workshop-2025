namespace OrderManagement.Application;

public interface IProductCatalogHttpService
{
    public Task<ProductResponse?> GetProductById(string id);
}