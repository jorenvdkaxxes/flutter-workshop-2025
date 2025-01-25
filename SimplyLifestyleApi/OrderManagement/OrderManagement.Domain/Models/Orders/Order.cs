using Common.Domain;

namespace OrderManagement.Domain;

public class Order : Entity, IAggregateRoot
{
    public HashSet<OrderItem> OrderItems { get; private set; }

    public Order(Guid customerId, DateTimeOffset deliveryDate)
    {
        ValidateDeliveryDate(deliveryDate);

        CustomerId = customerId;
        OrderDate = DateTimeOffset.UtcNow;
        DeliveryDate = deliveryDate;
        OrderItems = new HashSet<OrderItem>();
        Status = OrderStatus.Pending;
        
        RaiseEvent(new OrderAddedEvent());
    }

    public Guid CustomerId { get; private set; }
    public DateTimeOffset OrderDate { get; private set; }
    public DateTimeOffset DeliveryDate { get; private set; }
    public OrderStatus Status { get; private set; }

    public Order AddOrderItem(Guid productId, int quantity)
    {
        ValidateOrderItemQuantity(quantity);

        var orderItem = new OrderItem(Id, productId, quantity);
        OrderItems.Add(orderItem);

        return this;
    }

    public Order RemoveOrderItem(Guid orderItemId)
    {
        var orderItem = OrderItems.FirstOrDefault(oi => oi.Id == orderItemId);
        if (orderItem != null)
        {
            OrderItems.Remove(orderItem);
        }
        return this;
    }

    public Order UpdateStatus(OrderStatus status)
    {
        Status = status;
        return this;
    }

    public Order UpdateCustomerId(Guid customerId)
    {
        CustomerId = customerId;
        return this;
    }

    public Order UpdateOrderDate(DateTimeOffset orderDate)
    {
        ValidateOrderDate(orderDate);
        OrderDate = orderDate;
        return this;
    }

    public Order UpdateDeliveryDate(DateTimeOffset deliveryDate)
    {
        ValidateDeliveryDate(deliveryDate);
        DeliveryDate = deliveryDate;
        return this;
    }

    public Order UpdateOrderItem(Guid orderItemId, Guid productId, int quantity)
    {
        ValidateOrderItemQuantity(quantity);

        var orderItem = OrderItems.FirstOrDefault(oi => oi.Id == orderItemId);
        if (orderItem != null)
        {
            orderItem.UpdateProductId(productId);
            orderItem.UpdateQuantity(quantity);
        }
        return this;
    }

    private void ValidateOrderDate(DateTimeOffset orderDate)
    {
        if (orderDate > DateTimeOffset.UtcNow)
        {
            throw new ArgumentException("Order date cannot be in the future.");
        }
    }

    private void ValidateDeliveryDate(DateTimeOffset deliveryDate)
    {
        if (deliveryDate < DateTimeOffset.UtcNow)
        {
            throw new ArgumentException("Delivery date cannot be in the past.");
        }
    }

    private void ValidateOrderItemQuantity(int quantity)
    {
        if (quantity < OrderModelConstants.OrderItem.MinQuantity || quantity > OrderModelConstants.OrderItem.MaxQuantity)
        {
            throw new ArgumentException($"Order item quantity must be between {OrderModelConstants.OrderItem.MinQuantity} and {OrderModelConstants.OrderItem.MaxQuantity}.");
        }
    }
}
