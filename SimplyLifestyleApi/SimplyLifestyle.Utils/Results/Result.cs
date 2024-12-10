namespace SimplyLifestyle.Utils;

public class Result 
{
    private readonly List<ResultError> _errors = new List<ResultError>();

    protected Result() { }

    public Result(ResultError resultError)
    {
        ArgumentNullException.ThrowIfNull(resultError);
        _errors.Add(resultError);
    }
    
    public Result(IEnumerable<ResultError> resultErrors)
    {
        ArgumentNullException.ThrowIfNull(resultErrors);
        _errors.AddRange(resultErrors);
    }

    public Result(Exception exception)
    {
        ArgumentNullException.ThrowIfNull(exception);
        Exception = exception;
    }

    public Result(Exception exception, IEnumerable<ResultError> resultErrors)
    {
        ArgumentNullException.ThrowIfNull(exception);
        ArgumentNullException.ThrowIfNull(resultErrors);

        Exception = exception;
        _errors.AddRange(resultErrors);
    }

    public Result(Exception exception, ResultError resultError)
    {
        ArgumentNullException.ThrowIfNull(exception);
        ArgumentNullException.ThrowIfNull(resultError);

        Exception = exception;
        _errors.Add(resultError);
    }

    public Exception? Exception { get; }

    public bool IsSuccess => !Errors.Any() && Exception == null;

    public IEnumerable<ResultError> Errors => _errors.AsReadOnly();
}
