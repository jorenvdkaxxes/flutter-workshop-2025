namespace SimplyLifestyle.Application;

public interface IEventPublisher
{
    Task PublishApplicationEventsAsync(CancellationToken cancellationToken = default);

    Task PublishDomainEventsAsync(CancellationToken cancellationToken = default);
}
