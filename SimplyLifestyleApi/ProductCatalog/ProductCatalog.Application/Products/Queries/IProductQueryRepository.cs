public interface IProductQueryRepository : IQueryRepository<Product>
{
    Task<IEnumerable<ProductResponse>> GetAll(CancellationToken cancellationToken = default);

    Task<ProductResponse> GetDetailsById(Guid id, CancellationToken cancellationToken = default);
}