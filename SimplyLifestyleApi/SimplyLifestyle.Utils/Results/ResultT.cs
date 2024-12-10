namespace SimplyLifestyle.Utils;

public abstract class Result<TResult> : IResult<TResult>
{
    private readonly TResult _data = default!;

    protected Result()
        => HasValue = false;

    protected Result(TResult data)
    {
        _data = data;
        HasValue = true;
    }

    public bool HasValue { get; protected set; }

    public TResult Data
        => HasValue ? _data : throw new Exception($"{nameof(Data)} is null.");


    public static implicit operator TResult(Result<TResult> result) => result.Data;
}
