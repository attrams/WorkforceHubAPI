using System.ComponentModel.DataAnnotations;

namespace WorkforceHubAPI.Shared.DataTransferObjects;

/// <summary>
/// Represents a base class for manipulating employee data.
/// Serves as a common abstraction for both creation and update operations.
/// </summary>
public abstract record EmployeeForManipulationDto
{
    /// <summary>
    /// Gets or initializes the name of the employee.
    /// </summary>
    /// <remarks>
    /// This field is required and must not exceed 30 characters.
    /// </remarks>
    [Required(ErrorMessage = "Employee name is a required field.")]
    [MaxLength(30, ErrorMessage = "Maximum length for the Name is 30 characters.")]
    public string? Name { get; init; }

    /// <summary>
    /// Gets or initializes the age of the employee.
    /// </summary>
    /// <remarks>
    /// This field is required and must be at least 18.
    /// </remarks>
    [Range(18, int.MaxValue, ErrorMessage = "Age is required and it can't be lower than 18.")]
    public int Age { get; init; }

    /// <summary>
    /// Gets or initializes the position of the employee.
    /// </summary>
    /// <remarks>
    /// This field is required and must not exceed 40 characters.
    /// </remarks>
    [Required(ErrorMessage = "Position is a required field.")]
    [MaxLength(40, ErrorMessage = "Maximum length for the position is 40")]
    public string? Position { get; init; }
}