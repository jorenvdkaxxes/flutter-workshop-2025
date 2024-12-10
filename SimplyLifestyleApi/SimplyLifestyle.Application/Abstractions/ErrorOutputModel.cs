namespace SimplyLifestyle.Application;

public class ErrorOutputModel : IOutputModel
{
    public IEnumerable<ErrorModel> Errors { get; set; } = Enumerable.Empty<ErrorModel>();

    public bool IsSuccess => !Errors.Any();
}

public class ErrorModel
{
    public string ErrorType { get; set; } = default!;

    public string Description { get; set; } = default!;
}
