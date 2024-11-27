namespace WorkforceHubAPI.Shared.DataTransferObjects;

/// <summary>
/// Represents a Data Transfer Object (DTO) for Company Entity.
/// This DTO is used to transfer company data between the API and clients,
/// while ensuring that only the necessary information is exposed.
/// </summary>
/// <param name="Id">The unique identifier of the company.</param>
/// <param name="Name">The name of the company.</param>
/// <param name="FullAddress">The full address of the company, constructed by joining company's address and country.</param>
public record CompanyDto(Guid Id, string Name, string FullAddress);