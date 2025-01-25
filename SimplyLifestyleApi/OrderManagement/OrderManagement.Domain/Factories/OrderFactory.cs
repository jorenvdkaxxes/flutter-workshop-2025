namespace OrderManagement.Domain;

internal class OrderFactory : IOrderFactory
{
    private Guid customerId = default!;
    private DateTimeOffset deliveryDate = default!;

    private bool isCustomerIdSet = false;
    private bool isOrderDateSet = false;

    public IOrderFactory WithCustomerId(Guid customerId)
    {
        this.customerId = customerId;
        isCustomerIdSet = true;

        return this;
    }

    public IOrderFactory WithDeliveryDate(DateTimeOffset orderDate)
    {
        this.deliveryDate = orderDate;
        isOrderDateSet = true;

        return this;
    }

    public Order Build()
    {
        if (!isCustomerIdSet || !isOrderDateSet)
            throw new InvalidOperationException("Customer ID, order date must have a value.");

        return new Order(customerId, deliveryDate);
    }
}