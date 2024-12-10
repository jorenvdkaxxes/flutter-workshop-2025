using SimplyLifestyle.Domain;

namespace SimplyLifestyle.Application;

internal static class ProductExtensions
{
    internal static ProductOutputModel ToOutputModel(this Product product)
        => new()
        {
            Id = product.Id,
            Name = product.Name,
            Price = product.Price,
            Stock = product.Stock,
            IsConfigurable = product.IsConfigurable,
            Images = product.Images,
        };

    internal static IEnumerable<ProductOutputModel> ToOutputModels(this IEnumerable<Product> products)
        => products
            .Select(ToOutputModel)
            .ToList();
}
