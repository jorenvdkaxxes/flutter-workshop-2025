namespace SimplyLifestyle.Domain;

public record ProductId(Guid Value) : ITypedId
{
    public static implicit operator Guid(ProductId productId) => productId.Value;
    public static implicit operator string(ProductId productId) => productId.Value.ToString();
}
