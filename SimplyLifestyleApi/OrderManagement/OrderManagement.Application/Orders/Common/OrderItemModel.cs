using AutoMapper;
using Common.Application;
using OrderManagement.Domain;

namespace OrderManagement.Application;

public class OrderItemModel : IMapFrom<OrderItem>
{
    public Guid ProductId { get; set; }
    public int Quantity { get; set; }

    public virtual void Mapping(Profile mapper)
    {
        mapper.CreateMap<OrderItem, OrderItemModel>();
    }
}
