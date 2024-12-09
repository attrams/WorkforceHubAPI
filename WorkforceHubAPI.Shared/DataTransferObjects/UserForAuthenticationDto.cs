using System.ComponentModel.DataAnnotations;

namespace WorkforceHubAPI.Shared.DataTransferObjects;

/// <summary>
/// Data Transfer Object (DTO) for user authentication.
/// </summary>
/// <remarks>
/// Represents the credentials required for a user to authenticate. Both properties are mandatory.
/// </remarks>
public record UserForAuthenticationDto
{

    [Required(ErrorMessage = "User name is required.")]
    public string? UserName { get; init; }

    [Required(ErrorMessage = "Password is required.")]
    public string? Password { get; init; }
}