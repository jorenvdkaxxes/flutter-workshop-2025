namespace SimplyLifestyle.Domain;

public abstract class AggregateRoot<TId> : Entity<TId>, IAggregateRoot
    where TId : ITypedId
{
    public virtual IEnumerable<IDomainEvent> AllEvents()
    {
        var events = Events.ToList();
        ClearAllEvents();

        return events;
    }

    public virtual void ClearAllEvents()
        => ClearEvents();
}