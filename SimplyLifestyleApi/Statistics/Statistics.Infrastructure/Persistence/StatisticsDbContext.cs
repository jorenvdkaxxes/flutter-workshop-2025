using System.Reflection;
using Common.Infrastructure;
using Microsoft.EntityFrameworkCore;
using Statistics.Domain;

namespace Statistics.Infrastructure;

public class StatisticsDbContext : BaseDbContext<StatisticsDbContext>
{
    public StatisticsDbContext(
        DbContextOptions<StatisticsDbContext> options,
        IEventDispatcher eventDispatcher)
        : base(options, eventDispatcher)
    {
    }

    public DbSet<TotalStatistics> TotalStatistics { get; set; } = default!;

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

        base.OnModelCreating(modelBuilder);
    }
}
