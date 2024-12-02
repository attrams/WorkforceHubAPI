using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WorkforceHubAPI.Entities.Models;

/// <summary>
/// Represents a company entity in the application.
/// </summary>
public class Company
{
    /// <summary>
    /// Gets or sets the unique identifier for the company.
    /// </summary>
    [Column("CompanyId")]
    public Guid Id { get; set; }

    /// <summary>
    /// Gets or sets the name of the company.
    /// </summary>
    /// <remarks>
    /// This field is required and has a maximum length of 60 characters.
    /// </remarks>
    [Required(ErrorMessage = "Company name is a required field.")]
    [MaxLength(60, ErrorMessage = "Maximum length for the Name is 60 characters.")]
    public string? Name { get; set; }

    /// <summary>
    /// Gets or sets the address of the company.
    /// </summary>
    /// <remarks>
    /// This field is required and has a maximum length of 60 characters.
    /// </remarks>
    [Required(ErrorMessage = "Company address is a required field.")]
    [MaxLength(60, ErrorMessage = "Maximum length for the Address is 60 characters.")]
    public string? Address { get; set; }

    /// <summary>
    /// Gets or sets the country where the company is located.
    /// </summary>
    /// <remarks>
    /// This field is required and has a maximum length of 70 characters.
    /// </remarks>
    [Required(ErrorMessage = "Company country is a required field.")]
    [MaxLength(70, ErrorMessage = "Maximum length for the Country is 70 characters.")]
    public string? Country { get; set; }

    /// <summary>
    /// Navigation property for the collection of employees assiciated with the company.
    /// </summary>
    public ICollection<Employee>? Employees { get; set; }
}