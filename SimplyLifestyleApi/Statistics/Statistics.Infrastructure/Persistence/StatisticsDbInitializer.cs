using Common.Domain;
using Common.Infrastructure;
using Microsoft.Extensions.Logging;
using Statistics.Domain;

namespace Statistics.Infrastructure;

internal class StatisticsDbInitializer : DbInitializer
{
    public StatisticsDbInitializer(
        StatisticsDbContext db, ILogger<StatisticsDbInitializer> logger)
        : base(db, logger, new List<IInitialData> { new TotalStatisticsData() })
    {
    }
}