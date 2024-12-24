namespace SimplyLifestyle.Domain;

public record ProductCategoryId(Guid Value) : ITypedId
{
    public static implicit operator Guid(ProductCategoryId productId) => productId.Value;
    public static implicit operator string(ProductCategoryId productId) => productId.Value.ToString();
}
