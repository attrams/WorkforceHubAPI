using Microsoft.AspNetCore.Mvc;
using WorkforceHubAPI.Service.Contracts;
using WorkforceHubAPI.Shared.DataTransferObjects;
using WorkforceHubAPI.WebAPI.Presentation.ActionFilters;

namespace WorkforceHubAPI.WebAPI.Presentation.Controllers;

/// <summary>
/// Controller for handling token-related operations, such as refreshing access tokens.
/// </summary>
[Route("api/token")]
[ApiController]
public class TokenController : ControllerBase
{
    private readonly IServiceManager _service;

    public TokenController(IServiceManager service)
    {
        _service = service;
    }

    /// <summary>
    /// Endpoint to refresh an access token using a valid refresh token.
    /// </summary>
    /// <param name="tokenDto">The data transfer object containing the access token and refresh token.</param>
    /// <returns>An <see cref="IActionResult"/> containing the refreshed token data.</returns>
    [HttpPost("refresh")]
    [ServiceFilter(typeof(ValidationFilterAttribute))]
    public async Task<IActionResult> Refresh([FromBody] TokenDto tokenDto)
    {
        var tokenDtoToReturn = await _service.AuthenticationService.RefreshToken(tokenDto);

        return Ok(tokenDtoToReturn);
    }
}