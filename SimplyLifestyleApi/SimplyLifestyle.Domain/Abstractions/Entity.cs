namespace SimplyLifestyle.Domain;

public abstract class Entity<TId> : IEquatable<Entity<TId>>
    where TId : ITypedId
{
    private readonly IList<IDomainEvent> _events = new List<IDomainEvent>();

    public TId Id { get; protected set; } = default!;

    public IEnumerable<IDomainEvent> Events
        => _events
            .ToList()
            .AsReadOnly();

    public void AddEvent(IDomainEvent domainEvent)
        => _events.Add(domainEvent);

    public void ClearEvents()
        => _events.Clear();

    public bool Equals(Entity<TId>? other)
    {
        if (other is null)
            return false;

        if (ReferenceEquals(this, other))
            return true;

        return Id.Equals(other.Id);
    }

    public override bool Equals(object? obj)
    {
        if (obj is null)
            return false;

        if (ReferenceEquals(this, obj))
            return true;

        if (obj.GetType() != GetType())
            return false;

        return Equals((Entity<TId>)obj);
    }

    public static bool operator ==(Entity<TId>? obj, Entity<TId>? otherObj)
    {
        if (obj is null && otherObj is null)
            return true;

        if (obj is null || otherObj is null)
            return false;

        return obj.Equals(otherObj);
    }

    public static bool operator !=(Entity<TId>? obj, Entity<TId>? otherObj)
        => !(obj == otherObj);

    public override int GetHashCode()
        => (GetType().ToString() + Id).GetHashCode();
}
