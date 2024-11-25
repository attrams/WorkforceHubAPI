using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WorkforceHubAPI.Entities.Models;

/// <summary>
/// Represents an employee entity in the application.
/// </summary>
public class Employee
{
    /// <summary>
    /// Gets or sets the unique identifier for the employee.
    /// </summary>
    [Column("EmployeeId")]
    public Guid Id { get; set; }

    /// <summary>
    /// Gets or sets the name of the employee.
    /// </summary>
    /// <remarks>
    /// This field is required and has a maximum length of 30 characters.
    /// </remarks>
    [Required(ErrorMessage = "Employee name is a required field.")]
    [MaxLength(30, ErrorMessage = "Maximum length for the Name is 30 characters.")]
    public string? Name { get; set; }

    /// <summary>
    /// Gets or sets the age of the employee.
    /// </summary>
    /// <remarks>
    /// This field is required.
    /// </remarks>
    [Required(ErrorMessage = "Age is a required field.")]
    public int Age { get; set; }

    /// <summary>
    /// Gets or sets the position of the employee within the company.
    /// </summary>
    /// <remarks>
    /// This field is required and has a maximum length of 40 characters.
    /// </remarks>
    [Required(ErrorMessage = "Position is a required field.")]
    [MaxLength(40, ErrorMessage = "Maximum length for the position is 40")]
    public string? Position { get; set; }

    /// <summary>
    /// Gets or sets the identifier of the company the employee is associated with.
    /// </summary>
    [ForeignKey(nameof(Company))]
    public Guid CompanyId { get; set; }

    /// <summary>
    /// Navigation property for the associated company.
    /// </summary>
    public Company? Company { get; set; }
}
