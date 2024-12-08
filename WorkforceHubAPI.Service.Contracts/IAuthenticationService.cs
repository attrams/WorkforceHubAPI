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
}