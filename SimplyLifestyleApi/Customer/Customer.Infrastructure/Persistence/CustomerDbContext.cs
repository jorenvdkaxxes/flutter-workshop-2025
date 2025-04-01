using Common.Infrastructure;
using CustomerManagement.Domain.Models.Customers;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace CustomerManagement.Infrastructure.Persistence;

public class CustomerDbContext : BaseDbContext<CustomerDbContext>
{
    public CustomerDbContext(
        DbContextOptions<CustomerDbContext> options,
        IEventDispatcher eventDispatcher)
        : base(options, eventDispatcher)
    {
    }

    public DbSet<Customer> Customers { get; set; } = default!;

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

        base.OnModelCreating(modelBuilder);
    }
}