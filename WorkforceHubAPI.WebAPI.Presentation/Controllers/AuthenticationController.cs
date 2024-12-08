using Microsoft.AspNetCore.Mvc;
using WorkforceHubAPI.Service.Contracts;
using WorkforceHubAPI.Shared.DataTransferObjects;
using WorkforceHubAPI.WebAPI.Presentation.ActionFilters;

namespace WorkforceHubAPI.WebAPI.Presentation.Controllers;

/// <summary>
/// Controller responsible for handling authentication-related operations.
/// </summary>
[Route("api/authentication")]
[ApiController]
public class AuthenticationController : ControllerBase
{
    private readonly IServiceManager _service;

    public AuthenticationController(IServiceManager service)
    {
        _service = service;
    }

    /// <summary>
    /// Registers a new user in the system.
    /// </summary>
    /// <param name="userForRegistration">The user registration details received in the request body.</param>
    /// <returns>
    /// An <see cref="IActionResult"/> indicating the outcome of the registration:
    /// <para> - Returns <see cref="BadRequest"/> with validation errors if registration fails.</para>
    /// <para> - Returns a 201 status code if the user is successfully registered.</para>
    /// </returns>
    [HttpPost]
    [ServiceFilter(typeof(ValidationFilterAttribute))]
    public async Task<IActionResult> RegisterUser([FromBody] UserForRegistrationDto userForRegistration)
    {
        var result = await _service.AuthenticationService.RegisterUser(userForRegistration);

        if (!result.Succeeded)
        {
            foreach (var error in result.Errors)
            {
                ModelState.TryAddModelError(error.Code, error.Description);
            }

            return BadRequest(ModelState);
        }

        return StatusCode(201);
    }
}