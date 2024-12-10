using SimplyLifestyle.Utils;

namespace SimplyLifestyle.Domain;

public interface IDomainRule
{
    bool IsValid();

    Task<bool> IsValidAsync();

    string Message { get; }

    ResultError ResultError { get; }
}

public interface IObjectExistDomainRule<TObject> : IDomainRule
{
    TObject ExistedObject { get; }
}
