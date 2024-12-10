using Serilog.Core;
using Serilog.Events;

namespace SimplyLifestyle.Application;

internal class RequestLogEnricher<TResult> : OperationLogEnricher
{
    private readonly IRequest<TResult> _request;

    public RequestLogEnricher(IRequest<TResult> request, string operationName) : base(operationName)
        => _request = request;

    public override void AddOrUpdateProperties(LogEvent logEvent, ILogEventPropertyFactory propertyFactory)
    {
        var operationIdProperty = propertyFactory.CreateProperty("OperationId", _request.RequestId);
        logEvent.AddOrUpdateProperty(operationIdProperty);
    }
}
