using AutoMapper;
using CustomerManagement.Application.Products.Common;
using CustomerManagement.Domain.Models.Customers;

namespace CustomerManagement.Application;

public class CustomerResponse : CustomerModel
{
    public Guid Id { get; set; }
    
    public override void Mapping(Profile mapper)
        => mapper
            .CreateMap<Customer, CustomerResponse>()
            .IncludeBase<Customer, CustomerModel>();
}