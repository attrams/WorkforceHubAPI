namespace WorkforceHubAPI.Entities.Exceptions;

/// <summary>
/// Represents a specific exception that is thrown when the maximum age value is less than the minimum age value in a request.
/// </summary>
/// <remarks>
/// This exception is a specialized form of <see cref="BadRequestException"/> and is used to indicate that the 
/// maximum age range constraint has been violated in the context of a request, such as when validating filtering parameters.
/// </remarks>
public sealed class MaxAgeRangeBadRequestException : BadRequestException
{
    public MaxAgeRangeBadRequestException() : base("Max age can't be less than min age.")
    {
    }
}