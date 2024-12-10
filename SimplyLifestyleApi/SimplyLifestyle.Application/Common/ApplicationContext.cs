namespace SimplyLifestyle.Application;

public class ApplicationContext
{
    private readonly IDictionary<object, object> _items = new Dictionary<object, object>();

    public ApplicationContext()
    {
        InitializeApplicationEvents();
    }

    public IDictionary<object, object> Items
        => _items;

    public void RegisterEvent(IApplicationEvent applicationEvent)
    {
        if (Items.TryGetValue(ApplicationKeys.ApplicationEventsKey, out var value) &&
           value is Queue<IApplicationEvent> applicationEvents)
        {
            applicationEvents.Enqueue(applicationEvent);
        }
    }

    private void InitializeApplicationEvents()
    {
        var applicationEvents = new Queue<IApplicationEvent>();
        Items[ApplicationKeys.ApplicationEventsKey] = applicationEvents;
    }
}
