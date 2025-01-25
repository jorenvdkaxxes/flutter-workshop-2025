using AutoMapper;
using OrderManagement.Domain;

namespace OrderManagement.Application;

public class OrderResponse : OrderModel
{
    public int Id { get; set; }
    
    public override void Mapping(Profile mapper)
        => mapper
            .CreateMap<Order, OrderResponse>()
            .IncludeBase<Order, OrderModel>();
}