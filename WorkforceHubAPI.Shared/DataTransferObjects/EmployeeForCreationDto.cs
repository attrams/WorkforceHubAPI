namespace WorkforceHubAPI.Shared.DataTransferObjects;

/// <summary>
/// Represents the data transfer object for creating a new employee.
/// </summary>
/// <param name="Name">The name of the employee to be created.</param>
/// <param name="Age">The age of the employee to be created.</param>
/// <param name="Position">The position of the employee to be created.</param>
public record EmployeeForCreationDto(string Name, int Age, string Position);