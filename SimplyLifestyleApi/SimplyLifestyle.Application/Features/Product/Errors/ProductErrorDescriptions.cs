namespace SimplyLifestyle.Application;

public static class ProductErrorDescriptions
{
    public static string NoProductFound(string name) => $"No product found with name \"{name}\"";

    public static string ProductAlreadyExists(string name) => $"Product with name \"{name}\" already exist";
}
