using MediatR;
using SimplyLifestyle.Utils;

namespace SimplyLifestyle.Application;

public class TransactionBehavior<TRequest, TResponse> :
    IPipelineBehavior<TRequest, TResponse>
        where TRequest : ICommand<TResponse>
        where TResponse : Result
{
    public TransactionBehavior(ITransactionContext transactionContext, IEventPublisher eventPublisher)
    {
        TransactionContext = transactionContext;
        EventPublisher = eventPublisher;
    }

    protected ITransactionContext TransactionContext { get; init; }

    protected IEventPublisher EventPublisher { get; init; }

    public async Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
    {
        using (var transaction = TransactionContext.BeginTransaction())
        {
            var result = await next();

            if (!result.IsSuccess)
            {
                await transaction.RollbackAsync();

                return result;
            }

            await transaction.CommitAsync();

            await EventPublisher.PublishApplicationEventsAsync(cancellationToken);
            await EventPublisher.PublishDomainEventsAsync(cancellationToken);

            return result;
        }
    }
}
