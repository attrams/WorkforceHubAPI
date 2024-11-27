namespace WorkforceHubAPI.Shared.DataTransferObjects;

/// <summary>
/// Represents a Data Transfer Object (DTO) for the Employee entity, used to encapsulate and transfer data
/// between the service layer and presentation layer. The structure supports serialization to both JSON,
/// XML, and CSV formats, enabling flexible API responses.
/// </summary>
public record EmployeeDto
{
    /// <summary>
    /// Gets the unique identifier of the employee.
    /// </summary>
    public Guid Id { get; init; }

    /// <summary>
    /// Gets the name of the employee.
    /// </summary>
    public string? Name { get; init; }

    /// <summary>
    /// Gets the age of the employee.
    /// </summary>
    public int Age { get; init; }

    /// <summary>
    /// Gets the position of the employee.
    /// </summary>
    public string? Position { get; init; }
}