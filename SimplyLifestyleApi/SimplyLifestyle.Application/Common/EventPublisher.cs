using System.Diagnostics.CodeAnalysis;
using Microsoft.Extensions.Logging;
using MediatR;
using SimplyLifestyle.Domain;

namespace SimplyLifestyle.Application;

[ExcludeFromCodeCoverage]
public class EventPublisher : IEventPublisher
{
    private readonly ApplicationContext _applicationContext;
    private readonly IPublisher _publisher;
    private readonly ILogger<EventPublisher> _logger;

    public EventPublisher(ApplicationContext applicationContext, IPublisher publisher, ILogger<EventPublisher> logger) 
    { 
        _applicationContext = applicationContext;
        _publisher = publisher;
        _logger = logger;
    }

    public async Task PublishApplicationEventsAsync(CancellationToken cancellationToken = default)
    {
        if (_applicationContext.Items.TryGetValue(ApplicationKeys.ApplicationEventsKey, out var value) &&
           value is Queue<IApplicationEvent> applicationEvents)
        {
            while (applicationEvents.TryDequeue(out var applicationEvent))
            {
                await _publisher.Publish(applicationEvent, cancellationToken);

                LogApplicationEventData(applicationEvent);
            }
        }
    }

    public async Task PublishDomainEventsAsync(CancellationToken cancellationToken = default)
    {
        if (_applicationContext.Items.TryGetValue(ApplicationKeys.DomainEventsKey, out var value) &&
           value is Queue<IDomainEvent> domainEvents)
        {
            while (domainEvents.TryDequeue(out var domainEvent))
            {
                await _publisher.Publish(domainEvent, cancellationToken);

                LogDomainEventData(domainEvent);
            }
        }
    }

    private void LogApplicationEventData(IApplicationEvent applicationEvent)
    {
        if(applicationEvent is not EntitiesUpdatedEvent)
        {
            _logger.LogInformation($"Published application event: {applicationEvent.GetType().Name}");
            _logger.LogInformation("Event data: {@applicationEvent}", applicationEvent);
        }
    }

    private void LogDomainEventData(IDomainEvent domainEvent)
    {
        _logger.LogInformation($"Published domain event: {domainEvent.GetType().Name}");
        _logger.LogInformation("Event data: {@domainEvent}", domainEvent);
    }
}
