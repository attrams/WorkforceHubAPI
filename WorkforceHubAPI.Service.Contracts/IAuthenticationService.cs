using Microsoft.AspNetCore.Identity;
using WorkforceHubAPI.Shared.DataTransferObjects;

namespace WorkforceHubAPI.Service.Contracts;

/// <summary>
/// Defines authentication-related operations for the application.
/// </summary>
public interface IAuthenticationService
{
    /// <summary>
    /// Registers a new user in the system.
    /// </summary>
    /// <param name="userForRegistration">The data transfer object containing user registration details.</param>
    /// <returns>
    /// A task that represents the asynchronous operation. The task result contains an <see cref="IdentityResult"/> 
    /// indicating the result of the registration operation.
    /// </returns>
    Task<IdentityResult> RegisterUser(UserForRegistrationDto userForRegistration);

    /// <summary>
    /// Validates the provided user credentials.
    /// </summary>
    /// <param name="userForAuth">The <see cref="UserForAuthenticationDto"/> containing user credentials.</param>
    /// <returns>
    /// A <see cref="Task"/> representing the asynchronous operation. The task result is a boolean indicating whether
    /// the user credentials are valid.
    /// </returns>
    Task<bool> ValidateUser(UserForAuthenticationDto userForAuth);

    /// <summary>
    /// Creates and returns a new JWT access token and a refresh token for the authenticated user.
    /// </summary>
    /// <param name="populateExp">A boolean indicating whether to populate the refresh token's expiration.</param>
    /// <returns>
    /// A <see cref="Task"/> representing the asynchronous operation. The task result contains a <see cref="TokenDto"/> with
    /// the access token and refresh token.
    /// </returns>
    Task<TokenDto> CreateToken(bool populateExp);

    /// <summary>
    /// Refreshes access token using a valid refresh token.
    /// </summary>
    /// <param name="tokenDto">A Data Transfer Object containing the access token and refresh token.</param>
    /// <returns>A new <see cref="TokenDto"/> containing a refreshed access and refresh tokens.</returns>
    Task<TokenDto> RefreshToken(TokenDto tokenDto);
}