public class ProductType : Enumeration
{
    public static ProductType KaliSeats = new(0, nameof(KaliSeats));
    public static ProductType FabricSeats = new(1, nameof(FabricSeats));

    private ProductType(int value, string name)
        : base(value, name)
    {
    }

    private ProductType(int value)
        : this(value, FromValue<ProductType>(value).Name)
    {
    }
}