using OrderManagement.Application;
using System.Net.Http.Json;

namespace OrderManagement.Infrastructure;

public sealed class ProductCatalogHttpService : IProductCatalogHttpService
{
    private readonly HttpClient client;

    public ProductCatalogHttpService(HttpClient client)
    {
        this.client = client;
    }

    public async Task<ProductResponse?> GetProductById(string id)
        => await client.GetFromJsonAsync<ProductResponse>($"products/{id}");
}