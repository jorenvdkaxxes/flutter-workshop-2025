using SimplyLifestyle.Utils;

namespace SimplyLifestyle.Domain;

public abstract class Validatable
{
    private readonly List<ResultError> _ruleErrors = new();

    public OperationResult ValidateRuleWithResult(IDomainRule domainRule)
    {
        if (!domainRule.IsValid())
        {
            var error = new ResultError("Invalid domain rule", ResultErrorType.InvalidDomainObject, domainRule.Message);
            var errors = new List<ResultError> { error };

            return OperationResult.Failure(errors);
        }

        return OperationResult.Success();
    }

    public static async Task<OperationResult> ValidateRuleWithResultAsync(IDomainRule domainRule)
    {
        var isRuleValid = await domainRule.IsValidAsync();

        if (!isRuleValid)
        {
            var error = new ResultError("Invalid domain rule", ResultErrorType.InvalidDomainObject, domainRule.Message);
            var errors = new List<ResultError> { error };

            return OperationResult.Failure(errors);
        }

        return OperationResult.Success();
    }

    protected void ValidateRule(IDomainRule domainRule)
    {
        var isRuleValid = domainRule.IsValid();

        if (!isRuleValid)
        {
            _ruleErrors.Add(domainRule.ResultError);
        }
    }

    protected async Task ValidateRuleAsync(IDomainRule domainRule)
    {
        var isRuleValid = await domainRule.IsValidAsync();

        if (!isRuleValid)
        {
            _ruleErrors.Add(domainRule.ResultError);
        }
    }

    protected void AddError(ResultError error)
        => _ruleErrors.Add(error);

    protected void AddErrors(IEnumerable<ResultError> errors)
        => _ruleErrors.AddRange(errors);

    protected IEnumerable<ResultError> Errors
        => _ruleErrors.AsReadOnly();

    protected bool IsValidState
        => !_ruleErrors.Any();
}
