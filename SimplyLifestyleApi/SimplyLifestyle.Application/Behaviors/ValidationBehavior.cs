using FluentValidation;
using MediatR;
using SimplyLifestyle.Utils;

namespace SimplyLifestyle.Application;

public class ValidationBehavior<TRequest, TResponseData> : IPipelineBehavior<TRequest, OperationResult<TResponseData>>
    where TRequest : IRequest<OperationResult<TResponseData>>
    where TResponseData : IOutputModel
{
    public async Task<OperationResult<TResponseData>> Handle(TRequest request, RequestHandlerDelegate<OperationResult<TResponseData>> next, CancellationToken cancellationToken)
    {
        var validatorDescriptor = request as IModelValidatorDescriptor;

        if (validatorDescriptor is not null)
        {
            var validator = ValidatorFactory.Get(validatorDescriptor.ValidatorType);
            var context = new ValidationContext<TRequest>(request);

            var validationResult = validator.Validate(context);
            if (!validationResult.IsValid)
            {
                var resultErrors = validationResult
                                            .Errors
                                            .Select(item => new ResultError("InvalidData", ResultErrorType.Validation, item.ErrorMessage))
                                            .ToList();

                return OperationResult<TResponseData>.Failure(resultErrors);
            }
        }

        var response = await next();

        return response;
    }
}