namespace WorkforceHubAPI.Entities.Exceptions;

/// <summary>
/// Represents an exception that is thrown when an invalid ID format is encountered.
/// This exception is a specific type of <see cref="NotFoundException"/> used when the provided
/// ID does not match the expected format (GUID).
/// </summary>
public sealed class InvalidIdFormatException : NotFoundException
{
    /// <summary>
    /// Initializes a new instance of the <see cref="InvalidIdFormatException"/> class.
    /// </summary>
    /// <param name="message">The error message that explains the reason for the exception.</param>
    public InvalidIdFormatException(string message) : base(message)
    {
    }
}