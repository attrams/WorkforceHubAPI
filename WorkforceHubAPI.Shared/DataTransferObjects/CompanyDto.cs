namespace WorkforceHubAPI.Shared.DataTransferObjects;

/// <summary>
/// Represents a Data Transfer Object (DTO) for the Company entity, used to encapsulate and transfer data
/// between the service layer and presentation layer. The structure supports serialization to both JSON,
/// XML, and CSV formats, enabling flexible API responses.
/// </summary>
public record CompanyDto
{
    /// <summary>
    /// Gets the unique identifier of the company.
    /// </summary>
    public Guid Id { get; init; }

    /// <summary>
    /// Gets the name of the company.
    /// </summary>
    public string? Name { get; init; }

    /// <summary>
    /// Gets the full address of the company, constructed by combining the address and country.
    /// </summary>
    public string? FullAddress { get; init; }
}