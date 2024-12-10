using Serilog.Core;
using Serilog.Events;

namespace SimplyLifestyle.Application;

internal abstract class OperationLogEnricher : ILogEventEnricher
{
    private readonly string _operationName;

    public OperationLogEnricher(string operationName)
    {
        _operationName = operationName;
    }

    public void Enrich(LogEvent logEvent, ILogEventPropertyFactory propertyFactory)
    {
        var operationIdProperty = propertyFactory.CreateProperty("OperationName", _operationName);
        logEvent.AddOrUpdateProperty(operationIdProperty);

        AddOrUpdateProperties(logEvent, propertyFactory);
    }

    public abstract void AddOrUpdateProperties(LogEvent logEvent, ILogEventPropertyFactory propertyFactory);
}
