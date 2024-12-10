using Serilog.Core;
using Serilog.Events;

namespace SimplyLifestyle.Application;

internal class CommandLogEnricher<TResult> : OperationLogEnricher
{
    private readonly ICommand<TResult> _command;

    public CommandLogEnricher(ICommand<TResult> command, string operationName) : base(operationName)
        => _command = command;

    public override void AddOrUpdateProperties(LogEvent logEvent, ILogEventPropertyFactory propertyFactory)
    {
        var operationIdProperty = propertyFactory.CreateProperty("OperationId", _command.RequestId);
        logEvent.AddOrUpdateProperty(operationIdProperty);
    }
}
