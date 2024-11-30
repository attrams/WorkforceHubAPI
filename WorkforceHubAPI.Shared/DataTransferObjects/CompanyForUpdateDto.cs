namespace WorkforceHubAPI.Shared.DataTransferObjects;

/// <summary>
/// Represents the data transfer object used for updating a company's details.
/// </summary>
/// <param name="Name">The updated name of the company.</param>
/// <param name="Address">The updated address of the company.</param>
/// <param name="Country">The updated country where the company is located.</param>
/// <param name="Employees">A collection of employees to associate with the company.</param>
public record CompanyForUpdateDto(string Name, string Address, string Country, IEnumerable<EmployeeForCreationDto> Employees);