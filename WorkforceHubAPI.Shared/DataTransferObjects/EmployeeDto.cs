namespace WorkforceHubAPI.Shared.DataTransferObjects;

/// <summary>
/// Represents a Data Transfer Object (DTO) for Employee Entity.
/// This DTO is used to transfer employee data between the API and clients,
/// while ensuring that only the necessary information is exposed.
/// </summary>
/// <param name="Id">The unique identifier of the employee.</param>
/// <param name="Name">The name of the employee.</param>
/// <param name="Age">The age of the employee.</param>
/// <param name="Position">The position of the employee.</param>
public record EmployeeDto(Guid Id, string Name, int Age, string Position);