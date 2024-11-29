namespace WorkforceHubAPI.Shared.DataTransferObjects;

/// <summary>
/// Data Transfer Object for updating an employee's details.
/// </summary>
/// <param name="Name">The new name of the company.</param>
/// <param name="Age">The new age of the employee.</param>
/// <param name="Position">The new position of the employee within the company.</param>
public record EmployeeForUpdateDto(string Name, int Age, string Position);