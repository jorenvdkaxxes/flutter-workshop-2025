using Common.Domain;
using Common.Infrastructure;
using Statistics.Domain;

namespace Statistics.Infrastructure;

internal class StatisticsDbInitializer : DbInitializer
{
    public StatisticsDbInitializer(
        StatisticsDbContext db)
        : base(db, new List<IInitialData> { new TotalStatisticsData() })
    {
    }
}