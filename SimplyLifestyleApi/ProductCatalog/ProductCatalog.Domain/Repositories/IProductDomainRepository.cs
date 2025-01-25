using Common.Domain;

namespace ProductCatalog.Domain;

public interface IProductDomainRepository : IDomainRepository<Product>
{
    Task<Product> Find(Guid id, CancellationToken cancellationToken = default);
    Task Delete(Guid id, CancellationToken cancellationToken = default);
}