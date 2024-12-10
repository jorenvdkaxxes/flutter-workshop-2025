using SimplyLifestyle.Utils;

namespace SimplyLifestyle.Application;

public static class ProductErrors
{
    public static ResultError NoProductFound(string name)
        => new("INVALID_DATA", ResultErrorType.NotFound, ProductErrorDescriptions.NoProductFound(name));

    public static ResultError ProductAlreadyExists(string name)
        => new("INVALID_DATA", ResultErrorType.InvalidBusinessOperation, ProductErrorDescriptions.ProductAlreadyExists(name));
}
