namespace SimplyLifestyle.Application;

public interface ICommand
{
}

public interface ICommand<out TResult> : IRequest<TResult>, ICommand
{
}
