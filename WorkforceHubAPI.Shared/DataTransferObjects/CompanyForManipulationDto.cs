using System.ComponentModel.DataAnnotations;

namespace WorkforceHubAPI.Shared.DataTransferObjects;

/// <summary>
/// Represents a base class for manipulating company data.
/// Serves as a common abstraction for both creation and update operations.
/// </summary>
public abstract record CompanyForManipulationDto
{
    /// <summary>
    /// Gets or initializes the name of the company.
    /// </summary>
    /// <remarks>
    /// This field is required and must not exceed 60 characters.
    /// </remarks>
    [Required(ErrorMessage = "Company name is a required field.")]
    [MaxLength(60, ErrorMessage = "Maximum length for the Name is 60 characters.")]
    public string? Name { get; init; }

    /// <summary>
    /// Gets or initializes the address of the company.
    /// </summary>
    /// <remarks>
    /// This field is required and must not exceed 60 characters.
    /// </remarks>
    [Required(ErrorMessage = "Company address is a required field.")]
    [MaxLength(60, ErrorMessage = "Maximum length for the Address is 60 characters.")]
    public string? Address { get; init; }

    /// <summary>
    /// Gets or initializes the country the company is located.
    /// </summary>
    /// <remarks>
    /// This field is required and must not exceed 70 characters.
    /// </remarks>
    [Required(ErrorMessage = "Company country is a required field.")]
    [MaxLength(70, ErrorMessage = "Maximum length for the Country is 70 characters.")]
    public string? Country { get; init; }

    /// <summary>
    /// Gets or initializes the collection of employees associated with the company.
    /// </summary>
    /// <remarks>
    /// This field is optional.
    /// </remarks>
    public IEnumerable<EmployeeForCreationDto>? Employees { get; init; }
}