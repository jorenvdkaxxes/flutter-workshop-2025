using AutoMapper;

public record PriceRequest(decimal Amount, string Currency);

public class ProductModel : IMapFrom<Product>
{
    public string Name { get; set; } = default!;
    public string Description { get; set; } = default!;
    public int ProductType { get; set; }
    public PriceRequest Price { get; set; } = default!;
    public int Stock { get; set; }

    public virtual void Mapping(Profile mapper)
    {
        mapper.CreateMap<Product, ProductModel>()
            .ForMember(p => p.ProductType, opt => opt.MapFrom(src => src.ProductType.Value))
            .ForMember(p => p.Price, opt => opt.MapFrom(src => new PriceRequest(src.Price.Amount, src.Price.Currency)));
    }
}