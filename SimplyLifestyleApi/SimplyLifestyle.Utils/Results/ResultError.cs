namespace SimplyLifestyle.Utils;

public class ResultError
{
    public string Key { get; }

    public ResultErrorType ErrorType { get; }

    public string ErrorDescription { get; }

    public IDictionary<string, string> ErrorParameters { get; } = new Dictionary<string, string>();

    public ResultError(string key, ResultErrorType errorType, string errorDescription)
    {
        ArgumentNullException.ThrowIfNull(key);
        ArgumentNullException.ThrowIfNull(errorDescription);

        Key = key;
        ErrorType = errorType;
        ErrorDescription = errorDescription;
    }

    public ResultError(string key, ResultErrorType errorType, string errorDescription, Dictionary<string, string> errorParameters)
        : this(key, errorType, errorDescription)
    {
        ArgumentNullException.ThrowIfNull(errorParameters);
        ErrorParameters = errorParameters;
    }

    public ResultError AddResultParameter(string key, string value)
    {
        ArgumentNullException.ThrowIfNull(key);
        ArgumentNullException.ThrowIfNull(value);

        if (ErrorParameters.ContainsKey(key))
        {
            ErrorParameters[key] = value;
        }
        else
        {
            ErrorParameters.Add(key, value);
        }

        return this;
    }
}
