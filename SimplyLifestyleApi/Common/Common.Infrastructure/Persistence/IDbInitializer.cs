namespace Common.Infrastructure;

public interface IDbInitializer
{
    Task InitializeAsync();

    int Index { get; }
}