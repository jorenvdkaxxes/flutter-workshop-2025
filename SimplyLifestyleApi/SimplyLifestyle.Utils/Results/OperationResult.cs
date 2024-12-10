namespace SimplyLifestyle.Utils;

public class OperationResult : Result
{
    protected OperationResult()
    { }

    protected OperationResult(ResultError resultError)
        : base(resultError)
    {
    }

    protected OperationResult(IEnumerable<ResultError> resultErrors)
        : base(resultErrors)
    {
    }

    protected OperationResult(Exception exception)
        : base(exception)
    {
    }

    protected OperationResult(Exception exception, IEnumerable<ResultError> resultErrors)
        : base(exception, resultErrors)
    {
    }

    public static OperationResult Success()
        => new();

    public static OperationResult Failure(IEnumerable<ResultError> resultErrors)
        => new(resultErrors);

    public static OperationResult Failure(ResultError resultError)
        => new(resultError);

    public static OperationResult Failure(Exception exception)
        => new(exception);

    public static OperationResult Failure(Exception exception, IEnumerable<ResultError> resultErrors)
        => new(exception, resultErrors);
}
