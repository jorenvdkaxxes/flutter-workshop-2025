using AutoMapper;
using Common.Application;
using CustomerManagement.Domain.Models.Customers;

namespace CustomerManagement.Application.Products.Common;

public class CustomerModel : IMapFrom<Customer>
{
    public string FirstName { get; set; } = default!;

    public string LastName { get; set; } = default!;

    public virtual void Mapping(Profile mapper)
        => mapper.CreateMap<Customer, CustomerModel>();
}
