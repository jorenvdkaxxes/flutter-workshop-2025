using AutoMapper;
using Common.Infrastructure;
using Microsoft.EntityFrameworkCore;
using OrderManagement.Application;
using OrderManagement.Domain;

namespace OrderManagement.Infrastructure;

internal class OrderRepository : DataRepository<OrderManagementDbContext, Order>,
    IOrderDomainRepository,
    IOrderQueryRepository
{
    private readonly IMapper mapper;

    public OrderRepository(OrderManagementDbContext db, IMapper mapper)
        : base(db)
         => this.mapper = mapper;

    public Task<Order> Find(Guid id, CancellationToken cancellationToken = default)
    {
        // Implementation here
        throw new NotImplementedException();
    }

    public Task Delete(Guid id, CancellationToken cancellationToken = default)
    {
        // Implementation here
        throw new NotImplementedException();
    }

    public async Task<OrderResponse> GetDetailsById(Guid id, CancellationToken cancellationToken = default)
        => await mapper
            .ProjectTo<OrderResponse>(AllAsNoTracking()
                .Include(b => b.OrderItems)).FirstAsync(cancellationToken);

    public async Task<IEnumerable<OrderResponse>> GetAll(CancellationToken cancellationToken = default)
        => await mapper
            .ProjectTo<OrderResponse>(AllAsNoTracking()
                .Include(b => b.OrderItems)).ToListAsync(cancellationToken);
}
