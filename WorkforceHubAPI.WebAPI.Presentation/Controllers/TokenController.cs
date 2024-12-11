using System.Net.Mime;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WorkforceHubAPI.Entities.ErrorModel;
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

    /// <summary>
    /// Initializes a new instance of the <see cref="TokenController"/> class.
    /// </summary>
    /// <param name="service">
    /// An instance of <see cref="IServiceManager"/> used to manage services related to token generation and authentication operations.
    /// </param>
    public TokenController(IServiceManager service)
    {
        _service = service;
    }

    /// <summary>
    /// Endpoint to refresh an access token using a valid refresh token.
    /// </summary>
    /// <param name="tokenDto">The data transfer object containing the access token and refresh token.</param>
    /// <returns>An <see cref="IActionResult"/> containing the refreshed token data.</returns>
    /// <response code="201">Returns the newly created item.</response>
    /// <response code="400">If the item is null.</response>
    /// <response code="422">If the model is invalid</response>
    [HttpPost("refresh")]
    [ServiceFilter(typeof(ValidationFilterAttribute))]
    [Consumes(MediaTypeNames.Application.Json)]
    [ProducesResponseType(typeof(TokenDto), statusCode: StatusCodes.Status201Created, MediaTypeNames.Application.Json)]
    [ProducesResponseType(typeof(ErrorDetails), StatusCodes.Status400BadRequest, MediaTypeNames.Application.Json)]
    [ProducesResponseType(typeof(ErrorDetails), StatusCodes.Status422UnprocessableEntity, MediaTypeNames.Application.Json)]
    public async Task<IActionResult> Refresh([FromBody] TokenDto tokenDto)
    {
        var tokenDtoToReturn = await _service.AuthenticationService.RefreshToken(tokenDto);

        return Ok(tokenDtoToReturn);
    }
}