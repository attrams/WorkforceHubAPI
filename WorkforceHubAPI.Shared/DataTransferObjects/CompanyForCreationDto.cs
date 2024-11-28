namespace WorkforceHubAPI.Shared.DataTransferObjects;

/// <summary>
/// Data Transfer Object (DTO) used for creating a new company.
/// </summary>
/// <param name="Name">The name of the company.</param>
/// <param name="Address">The address of the company.</param>
/// <param name="Country">The country where the company is located.</param>
/// <param name="Employees">An optional list of employees to be associated with the company during its creation.</param>
public record CompanyForCreationDto(string Name, string Address, string Country, IEnumerable<EmployeeForCreationDto> Employees);