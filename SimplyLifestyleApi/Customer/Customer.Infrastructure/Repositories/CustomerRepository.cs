using AutoMapper;
using Common.Infrastructure;
using CustomerManagement.Application;
using CustomerManagement.Application.Customers.Queries;
using CustomerManagement.Domain.Models.Customers;
using CustomerManagement.Domain.Repositories;
using CustomerManagement.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace CustomerManagement.Infrastructure.Repositories;

public class CustomerRepository : DataRepository<CustomerDbContext, Customer>,
    ICustomerDomainRepository,
    ICustomerQueryRepository
{
    private readonly IMapper _mapper;

    public CustomerRepository(CustomerDbContext db, IMapper mapper) : base(db)
    {
        _mapper = mapper;
    }

    public async Task<Customer> FindByIdAsync(Guid id, CancellationToken cancellationToken = default)
        => await All()
                .FirstAsync(b => b.Id == id, cancellationToken);

    public async Task<IEnumerable<CustomerResponse>> GetAllAsync(CancellationToken cancellationToken = default)
        => await _mapper
            .ProjectTo<CustomerResponse>(AllAsNoTracking()).ToListAsync(cancellationToken);
}
