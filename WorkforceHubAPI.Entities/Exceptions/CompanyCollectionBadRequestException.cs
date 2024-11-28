namespace WorkforceHubAPI.Entities.Exceptions;

/// <summary>
/// Exception thrown when a company collection sent by the client is null or empty.
/// </summary>
public sealed class CompanyCollectionBadRequestException : BadRequestException
{
    public CompanyCollectionBadRequestException() : base("Company collection sent from the client is null.")
    {
    }
}