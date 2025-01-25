using Common.Domain;

namespace Common.Infrastructure;

public interface IEventDispatcher
{
    Task Dispatch(IDomainEvent domainEvent);
}