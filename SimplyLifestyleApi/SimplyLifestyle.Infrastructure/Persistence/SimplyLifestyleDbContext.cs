using Microsoft.EntityFrameworkCore;
using SimplyLifestyle.Domain;
using System.Reflection;

namespace SimplyLifestyle.Infrastructure;

public class SimplyLifestyleDbContext : DbContext
{
    public SimplyLifestyleDbContext(
           DbContextOptions<SimplyLifestyleDbContext> options)
               : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.UseAsyncSeeding(async (context, _, cancellationToken) =>
        {
            var productCategories = context.Set<ProductCategory>();
            if (!productCategories.Any())
            {
                var products = new List<Product>
                {
                    new Product(new ProductId(Guid.NewGuid()), "Nathan", 2199.99f, 5, false, "nathan-1", "nathan-2")
                };
                var productCategory = new ProductCategory(new ProductCategoryId(Guid.NewGuid()), "Stoffen zetels", products);
                context.Set<ProductCategory>().Add(productCategory);
                await context.SaveChangesAsync(cancellationToken);
            }
        });
}
