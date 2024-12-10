using Microsoft.EntityFrameworkCore;
using SimplyLifestyle.Application;
using SimplyLifestyle.Domain;

namespace SimplyLifestyle.Infrastructure;

public class ProductRepository : Repository<Product>, IProductRepository
{
    private readonly SimplyLifestyleDbContext _context;

    public ProductRepository(SimplyLifestyleDbContext context) : base(context)
    {
        _context = context;
    }

    public async Task<IEnumerable<Product>> FindAllAsync(CancellationToken cancellationToken = default)
    {
        var products = await All()
                                .ToListAsync(cancellationToken);

        return products;
    }

    public async Task<Product?> FindByIdAsync(Guid id, CancellationToken cancellationToken = default)
    {
        var product = await All()
                                .FirstOrDefaultAsync(p => p.Id == id, cancellationToken);

        return product;
    }

    public async Task<Product?> FindByNameAsync(string name, CancellationToken cancellationToken = default)
    {
        var product = await All()
                                .FirstOrDefaultAsync(p => p.Name == name, cancellationToken);

        return product;
    }
}
