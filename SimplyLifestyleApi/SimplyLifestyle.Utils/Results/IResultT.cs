namespace SimplyLifestyle.Utils;

public interface IResult<TResult>
{
    public bool HasValue { get; }

    public TResult Data { get; }

}
