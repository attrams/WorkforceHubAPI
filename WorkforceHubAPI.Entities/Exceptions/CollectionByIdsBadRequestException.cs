namespace WorkforceHubAPI.Entities.Exceptions;

/// <summary>
/// Represents an exception that is thrown when some of the IDs provided for retrieving a collection of companies are
/// invalid or do not correspond to any existing entities in the database.
/// </summary>
public sealed class CollectionByIdsBadRequestException : BadRequestException
{
    public CollectionByIdsBadRequestException() : base("Some of the provided IDs are invalid or do not exist in the database. Please verify the list and try again.")
    {
    }
}