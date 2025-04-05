namespace OrderManagement.Domain;

internal class OrderFactory : IOrderFactory
{
    private Guid _customerId = default!;
    private DateTimeOffset _orderDate = default!;

    private bool isCustomerIdSet = false;
    private bool isDeliveryDateSet = false;

    public IOrderFactory WithCustomerId(Guid customerId)
    {
        _customerId = customerId;
        isCustomerIdSet = true;

        return this;
    }

    public IOrderFactory WithDeliveryDate(DateTimeOffset deliveryDate)
    {
        _orderDate = deliveryDate;
        isDeliveryDateSet = true;

        return this;
    }

    public Order Build()
    {
        if (!isCustomerIdSet || !isDeliveryDateSet)
            throw new InvalidOperationException("Customer ID, order date must have a value.");

        return new Order(_customerId, _orderDate);
    }
}