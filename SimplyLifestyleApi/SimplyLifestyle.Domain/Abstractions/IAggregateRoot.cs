namespace SimplyLifestyle.Domain;

public interface IAggregateRoot
{
    public IEnumerable<IDomainEvent> AllEvents();

    public void ClearAllEvents();
}
