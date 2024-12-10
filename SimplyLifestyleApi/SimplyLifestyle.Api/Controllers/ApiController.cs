using Microsoft.AspNetCore.Mvc;
using MediatR;
using SimplyLifestyle.Utils;

namespace SimplyLifestyle.Application;

[ApiController]
public abstract class ApiController : ControllerBase
{
    private IMediator? _mediator;

    protected IMediator Mediator
        => _mediator ??= HttpContext.RequestServices.GetService<IMediator>()!;

    protected IActionResult ToActionResult<TOutput>(OperationResult<TOutput> result)
    {
        if (result.IsSuccess)
        {
            return Ok(result.Data!);
        }
        else if (result.Errors.Any(e => e.ErrorType == ResultErrorType.NotFound))
        {
            return NotFound(result.Errors);
        }
        
        return BadRequest(result.Errors);
    }

    //For Templates only
    protected IActionResult ToOutput<TOutputModel>(OperationResult<TOutputModel> result)
        where TOutputModel : IOutputModel, new()
    {
        if (result.IsSuccess)
        {
            return Ok(result.Data!);
        }
        else if (result.Errors.Any(e => e.ErrorType == ResultErrorType.NotFound))
        {
            var notFoundErrorOutputModel = GetErrorOutputModel(result.Errors);
            
            return NotFound(notFoundErrorOutputModel);
        }

        var badRequestErrorOutputModel = GetErrorOutputModel(result.Errors);
        
        return BadRequest(badRequestErrorOutputModel);
    }

    private ErrorOutputModel GetErrorOutputModel(IEnumerable<ResultError> errors)
    {
        var errorModels = GetErrorModel(errors);
        var errorOutputModel = new ErrorOutputModel();
        errorOutputModel.Errors = errorModels;

        return errorOutputModel;
    }

    private IEnumerable<ErrorModel> GetErrorModel(IEnumerable<ResultError> errors)
    {
        var errorModels = errors
                            .Select(item =>
                                new ErrorModel
                                {
                                    ErrorType = item.ErrorType.ToString(),
                                    Description = item.ErrorDescription
                                })
                            .ToList();

        return errorModels;
    }
}
