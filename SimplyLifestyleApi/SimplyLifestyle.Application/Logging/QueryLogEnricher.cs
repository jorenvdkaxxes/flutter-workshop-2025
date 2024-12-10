using Serilog.Core;
using Serilog.Events;

namespace SimplyLifestyle.Application;

internal class QueryLogEnricher<TResult> : OperationLogEnricher
{
    private readonly IQuery<TResult> _query;

    public QueryLogEnricher(IQuery<TResult> query, string operationName) : base(operationName) 
        => _query = query;

    public override void AddOrUpdateProperties(LogEvent logEvent, ILogEventPropertyFactory propertyFactory)
    {
        var operationIdProperty = propertyFactory.CreateProperty("OperationId", _query.RequestId);
        logEvent.AddOrUpdateProperty(operationIdProperty);
    }
}
