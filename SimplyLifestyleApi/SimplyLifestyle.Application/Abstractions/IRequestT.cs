namespace SimplyLifestyle.Application;

public interface IRequest : MediatR.IRequest
{
}

public interface IRequest<out TResult> : MediatR.IRequest<TResult>
{
    Guid RequestId { get; }
}
