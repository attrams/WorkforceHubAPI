namespace WorkforceHubAPI.Entities.Exceptions;

/// <summary>
/// Exception to represent an invalid client request when refresh tokens.
/// </summary>
public sealed class RefreshTokenBadRequestException : BadRequestException
{
    public RefreshTokenBadRequestException() : base("Invalid client request. The tokenDto has some invalid values.")
    {
    }
}