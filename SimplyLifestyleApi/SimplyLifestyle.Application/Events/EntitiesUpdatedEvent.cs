namespace SimplyLifestyle.Application;

public class EntitiesUpdatedEvent : IApplicationEvent
{
    private readonly IEnumerable<object> _entities;

    public EntitiesUpdatedEvent(IEnumerable<object> entities)
    {
        ArgumentNullException.ThrowIfNull(entities);
        _entities = entities;
    }

    public IEnumerable<object> Entities
        => _entities.ToList().AsReadOnly();
}
