namespace WorkforceHubAPI.Entities.Exceptions;

/// <summary>
/// Serves as a base class for all "not found" exception types.
/// </summary>
/// <remarks>
/// This class provides a foundation for defining exceptions that indicate an entity or resource
/// could not be located. Derived classes can specify the resource type and additional context.
/// </remarks>
public abstract class NotFoundException : Exception
{
    /// <summary>
    /// Initializes a new instance of the <see cref="NotFoundException"/> class with a specific error message.
    /// </summary>
    /// <param name="message">The error message that explains the reason for the exception.</param>
    protected NotFoundException(string message) : base(message)
    {

    }
}