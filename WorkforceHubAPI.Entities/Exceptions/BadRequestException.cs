namespace WorkforceHubAPI.Entities.Exceptions;

/// <summary>
/// Custom exception for handling bad requests when the input is invalid or null.
/// </summary>
public class BadRequestException : Exception
{
    public BadRequestException(string message) : base(message)
    {
    }
}