using Microsoft.AspNetCore.Identity;

namespace WorkforceHubAPI.Entities.Models;

/// <summary>
/// Represents a user in the application by inheriting from <see cref="IdentityUser"/> to include identity-related properties.
/// </summary>
public class User : IdentityUser
{
    public string? FirstName { get; set; }
    public string? LastName { get; set; }
}