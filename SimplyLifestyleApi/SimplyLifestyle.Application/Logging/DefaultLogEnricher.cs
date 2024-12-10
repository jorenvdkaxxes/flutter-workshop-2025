using Serilog.Core;
using Serilog.Events;

namespace SimplyLifestyle.Application;

internal class DefaultLogEnricher : ILogEventEnricher
{
    public void Enrich(LogEvent logEvent, ILogEventPropertyFactory propertyFactory)
    {
    }
}
