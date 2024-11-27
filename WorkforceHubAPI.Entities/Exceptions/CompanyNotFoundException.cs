namespace WorkforceHubAPI.Entities.Exceptions;

/// <summary>
/// Exception thrown when a company is not found in the database.
/// </summary>
/// <remarks>
/// This exception is specifically used to indicate that a company with the given identifier does not
/// exist in the database.
/// </remarks>
public sealed class CompanyNotFoundException : NotFoundException
{
    /// <summary>
    /// Initializes a new instance of <see cref="CompanyNotFoundException"/> class with the company ID.
    /// </summary>
    /// <param name="companyId">The unique identifier of the company that was not found.</param>
    public CompanyNotFoundException(Guid companyId) : base($"The company with id: {companyId} doesn't exist in the database.")
    {
    }
}