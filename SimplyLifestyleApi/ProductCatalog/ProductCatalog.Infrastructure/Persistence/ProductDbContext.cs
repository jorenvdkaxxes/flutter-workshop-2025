using System.Reflection;
using Common.Infrastructure;
using Microsoft.EntityFrameworkCore;
using ProductCatalog.Domain;

namespace ProductCatalog.Infrastructure;

internal class ProductDbContext : BaseDbContext<ProductDbContext>
{
    public ProductDbContext(
        DbContextOptions<ProductDbContext> options,
        IEventDispatcher eventDispatcher)
        : base(options, eventDispatcher)
    {
    }

    public DbSet<Supplier> Suppliers { get; set; } = default!;
    public DbSet<Product> Products { get; set; } = default!;
    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

        base.OnModelCreating(modelBuilder);
    }
}
