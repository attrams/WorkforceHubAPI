namespace WorkforceHubAPI.Shared.DataTransferObjects;

/// <summary>
/// Represents a Data Transfer Object (DTO) for returning access and refresh tokens.
/// </summary>
/// <param name="AccessToken">The JWT access token for user authentication.</param>
/// <param name="RefreshToken">The refresh token used to obtain a new access token after expiration.</param>
public record TokenDto(string AccessToken, string RefreshToken);