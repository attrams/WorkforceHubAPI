namespace WorkforceHubAPI.Entities.Exceptions;

/// <summary>
/// Represents an exception that is thrown when the 'ids' parameter for retrieving a collection of companies is null.
/// </summary>
public sealed class IdParametersBadRequestException : BadRequestException
{
    public IdParametersBadRequestException() : base("Parameter 'ids' is null.")
    {
    }
}