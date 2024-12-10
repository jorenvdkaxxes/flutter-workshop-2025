using System.Diagnostics;
using System.Text.Json;
using Microsoft.Extensions.Logging;
using MediatR;
using SimplyLifestyle.Utils;
using Serilog.Core;
using Serilog.Context;

namespace SimplyLifestyle.Application;

public class RequestLoggingBehavior<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse>
    where TRequest : IRequest<TResponse>
    where TResponse : Result
{
    private readonly Stopwatch _timer = new();
    private readonly ILogger<RequestLoggingBehavior<TRequest, TResponse>> _logger;

    public RequestLoggingBehavior(ILogger<RequestLoggingBehavior<TRequest, TResponse>> logger)
        => _logger = logger;

    public async Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
    {
        var enricher = GetLogEnricher(request);
        using (LogContext.Push(enricher))
        {
            var requestName = typeof(TRequest).Name;
            var requestData = ToJson(request);
            StartRequestLogging(requestName, requestData);

            var response = await next();

            if (response.IsSuccess)
            {
                var responseData = ToJson(response);
                CompleteRequestLogging(requestName, responseData);
            }
            else 
            {
                CompleteRequestWithErrorsLogging(requestName, response.Errors);
            }

            StopRequestLogging(requestName);

            return response;
        }
    }

    private void StartRequestLogging(string requestName, string requestData)
    {
        _timer.Start();
        _logger.LogInformation($"Processing {requestName}");
        _logger.LogInformation($"Request Data {requestData}");
    }

    private void StopRequestLogging(string requestName)
    {
        _timer.Stop();
        var elapsedMilliseconds = _timer.ElapsedMilliseconds;
        _logger.LogInformation($"Processed {requestName} Milliseconds {elapsedMilliseconds}");
    }

    private void CompleteRequestLogging(string requestName, string responseData)
    {
        _logger.LogInformation($"Response Data {responseData}");
        _logger.LogInformation($"Completed {requestName} Successfully");
    }

    private void CompleteRequestWithErrorsLogging(string requestName, IEnumerable<ResultError> errors)
    {
        var logErrors = errors
                            .Select(c => new 
                            { 
                               c.ErrorType,
                               c.ErrorDescription
                            })
                            .ToList();

        using(LogContext.PushProperty("Errors", logErrors, true))
        {
            _logger.LogError($"Completed {requestName} With Errors");
        }
    }

    private static ILogEventEnricher GetLogEnricher(TRequest request)
        => request switch
        {
            ICommand<TResponse> => new CommandLogEnricher<TResponse>((ICommand<TResponse>)request, typeof(TRequest).Name),
            IQuery<TResponse>   => new QueryLogEnricher<TResponse>((IQuery<TResponse>)request, typeof(TRequest).Name),
            IRequest<TResponse> => new RequestLogEnricher<TResponse>(request, typeof(TRequest).Name),

            _                   => new DefaultLogEnricher()
        };

    private static string ToJson(object obj)
        => JsonSerializer.Serialize(obj);
}
