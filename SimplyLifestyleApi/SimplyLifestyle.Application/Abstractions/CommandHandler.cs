using Microsoft.Extensions.Logging;
using SimplyLifestyle.Utils;

namespace SimplyLifestyle.Application;

public abstract class CommandHandler<TCommand, TResult, TResultData> : ICommandHandler<TCommand, TResult>
    where TCommand : ICommand<TResult>
    where TResult : OperationResult<TResultData>
    where TResultData : IOutputModel
{
    public CommandHandler(ILogger<CommandHandler<TCommand, TResult, TResultData>> logger)
        => Logger = logger;

    public async Task<TResult> Handle(TCommand command, CancellationToken cancellationToken)
    {
        try
        {
            var result = await HandleCore(command, cancellationToken);

            return result;
        }
        catch (Exception ex)
        {
            Logger.LogError(ex, $"Application error: {ex.Message}");
            var error = new ResultError("", ResultErrorType.InternalServerError, "Internal Server Error");

            return (TResult)OperationResult<TResultData>.Failure(ex, error);
        }
    }

    protected ILogger<CommandHandler<TCommand, TResult, TResultData>> Logger { get; init; }

    protected abstract Task<TResult> HandleCore(TCommand command, CancellationToken cancellationToken);
}