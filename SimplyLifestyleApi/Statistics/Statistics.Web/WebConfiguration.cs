using Common.Web;
using Microsoft.Extensions.DependencyInjection;
using Statistics.Application;

namespace Statistics.Web;

public static class WebConfiguration
{
    public static IServiceCollection AddStatisticsWebComponents(
        this IServiceCollection services)
        => services.AddWebComponents(
            typeof(StatisticsApplicationConfiguration));
}