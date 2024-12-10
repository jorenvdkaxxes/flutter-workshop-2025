namespace SimplyLifestyle.Utils;

public class OperationResult<TResult> : Result
{
    private readonly TResult _data = default!;

    protected OperationResult()
        => HasValue = false;

    protected OperationResult(TResult data)
    {
        _data = data;
        HasValue = true;
    }

    protected OperationResult(ResultError resultError)
        : base(resultError) 
        => HasValue = false;

    protected OperationResult(IEnumerable<ResultError> resultErrors)
        : base(resultErrors)
        => HasValue = false;

    protected OperationResult(Exception exception)
        : base(exception)
        => HasValue = false;

    protected OperationResult(Exception exception, ResultError resultError)
        : base(exception, resultError)
        => HasValue = false;

    protected OperationResult(Exception exception, IEnumerable<ResultError> resultErrors)
        : base(exception, resultErrors)
        => HasValue = false;

    public static OperationResult<TResult> Success(TResult data)
        => new(data);

    public static OperationResult<TResult> Failure(ResultError resultError)
        => new(resultError);

    public static OperationResult<TResult> Failure(IEnumerable<ResultError> resultErrors)
        => new(resultErrors);

    public static OperationResult<TResult> Failure(Exception exception)
        => new(exception);

    public static OperationResult<TResult> Failure(Exception exception, ResultError resultError)
        => new(exception, resultError);

    public static OperationResult<TResult> Failure(Exception exception, IEnumerable<ResultError> resultErrors)
        => new(exception, resultErrors);

    public bool HasValue { get; protected set; }

    public TResult Data
        => HasValue ? _data : throw new Exception($"{nameof(Data)} is null.");

    public new bool IsSuccess => !Errors.Any() && Exception == null;

    public static implicit operator TResult(OperationResult<TResult> result) => result.Data;
}
