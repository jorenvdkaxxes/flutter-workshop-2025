using Microsoft.Extensions.Logging;
using SimplyLifestyle.Utils;
using System.Diagnostics.CodeAnalysis;

namespace SimplyLifestyle.Application;

[ExcludeFromCodeCoverage]
public abstract class QueryHandler<TQuery, TResult, TResultData> : 
    IQueryHandler<TQuery, TResult>
        where TQuery : IQuery<TResult>
        where TResult : OperationResult<TResultData>
        where TResultData : IOutputModel
{
    public QueryHandler(ILogger<QueryHandler<TQuery, TResult, TResultData>> logger)
        => Logger = logger;
    
    public async Task<TResult> Handle(TQuery query, CancellationToken cancellationToken)
    {
        try
        {
            return await HandleCore(query, cancellationToken);
        }
        catch (Exception ex)
        {
            Logger.LogError(ex, $"Application error: {ex.Message}");
            var error = new ResultError("", ResultErrorType.InternalServerError, "Internal Server Error");

            return (TResult)OperationResult<TResultData>.Failure(ex, error);
        }
    }

    protected ILogger<QueryHandler<TQuery, TResult, TResultData>> Logger { get; init; }

    protected abstract Task<TResult> HandleCore(TQuery query, CancellationToken cancellationToken);
}
