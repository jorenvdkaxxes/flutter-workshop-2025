using Common.Application;
using Statistics.Domain;

namespace Statistics.Application;

public interface IStatisticsQueryRepository : IQueryRepository<TotalStatistics>
{
}