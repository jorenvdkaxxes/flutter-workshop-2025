namespace Common.Domain;

public interface IEntity
{
    IReadOnlyCollection<IDomainEvent> Events { get; }

    void ClearEvents();
}