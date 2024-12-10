using SimplyLifestyle.Domain;

namespace SimplyLifestyle.Application;

public interface IProductRepository : IRepository<Product>
{
    Task<IEnumerable<Product>> FindAllAsync(CancellationToken cancellationToken = default);

    Task<Product?> FindByIdAsync(Guid id, CancellationToken cancellationToken = default);

    Task<Product?> FindByNameAsync(string name, CancellationToken cancellationToken = default);
}
