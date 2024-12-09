using WorkforceHubAPI.Contracts;
using WorkforceHubAPI.Entities.Exceptions;
using WorkforceHubAPI.Entities.Models;
using WorkforceHubAPI.Service.Contracts;
using WorkforceHubAPI.Shared.DataTransferObjects;

using System.Security.Claims;
using System.Text;
using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using Microsoft.IdentityModel.JsonWebTokens;

namespace WorkforceHubAPI.Service;

/// <summary>
/// Implements the authentication operations defined in <see cref="IAuthenticationService"/>.
/// </summary>
internal sealed class AuthenticationService : IAuthenticationService
{
    private readonly ILoggerManager _logger;
    private readonly IMapper _mapper;
    private readonly UserManager<User> _userManager;
    private readonly RoleManager<IdentityRole> _roleManager;
    private readonly IConfiguration _configuration;
    private User? _user;

    public AuthenticationService(
        ILoggerManager logger,
        IMapper mapper,
        UserManager<User> userManager,
        RoleManager<IdentityRole> roleManager,
        IConfiguration configuration
    )
    {
        _logger = logger;
        _mapper = mapper;
        _userManager = userManager;
        _roleManager = roleManager;
        _configuration = configuration;
    }

    /// <inheritdoc/>
    /// <exception cref="RoleNotFoundException">Thrown when a specified role does not exist in the system.</exception>
    public async Task<IdentityResult> RegisterUser(UserForRegistrationDto userForRegistration)
    {
        // Validate all roles before creating the user.
        foreach (var role in userForRegistration.Roles!)
        {
            if (!await _roleManager.RoleExistsAsync(role))
            {
                _logger.LogError($"Role '{role}' does not exist.");
                throw new RoleNotFoundException(role);
            }
        }

        var user = _mapper.Map<User>(userForRegistration);
        var result = await _userManager.CreateAsync(user, userForRegistration.Password!);

        if (result.Succeeded)
        {
            await _userManager.AddToRolesAsync(user, userForRegistration.Roles!);
        }

        return result;
    }

    /// <inheritdoc/>
    public async Task<bool> ValidateUser(UserForAuthenticationDto userForAuth)
    {
        _user = await _userManager.FindByNameAsync(userForAuth.UserName!);
        var result = _user is not null && await _userManager.CheckPasswordAsync(_user, userForAuth.Password!);

        if (!result)
        {
            _logger.LogWarn($"{nameof(ValidateUser)}: Authentication failed. Wrong username or password.");
        }

        return result;
    }

    /// <inheritdoc/>
    public async Task<string> CreateToken()
    {
        var signingCredentials = GetSigningCredentials();
        var claims = await GetClaims();
        var tokenOptions = GenerateTokenOptions(signingCredentials, claims);

        var handler = new JsonWebTokenHandler();
        handler.SetDefaultTimesOnTokenCreation = false;

        return handler.CreateToken(tokenOptions);
    }

    /// <summary>
    /// Retrieves signing credentials for token generation using the secret key defined in configuration.
    /// </summary>
    /// <returns>
    /// A <see cref="SigningCredentials"/> object containing the secret key and the HMAC SHA-256 security algorithm.
    /// </returns>
    private SigningCredentials GetSigningCredentials()
    {
        var key = Encoding.UTF8.GetBytes(_configuration.GetSection("JwtSettings")["SecretKey"]!);
        var secret = new SymmetricSecurityKey(key);

        return new SigningCredentials(secret, SecurityAlgorithms.HmacSha256);
    }

    /// <summary>
    /// Generates a dictionary of claims for the authenticated userm including roles.
    /// </summary>
    /// <returns>
    /// A <see cref="Task"/> representing the asynchronous operation. The task result is a dictionary of claims,
    /// where the keys are claim types (e.g., Name, Role) and the respective claim values.
    /// </returns>
    private async Task<Dictionary<string, object>> GetClaims()
    {
        var claims = new Dictionary<string, object>
        {
            {ClaimTypes.Name, _user?.UserName!}
        };

        var roles = await _userManager.GetRolesAsync(_user!);
        foreach (var role in roles)
        {
            claims.Add(ClaimTypes.Role, role);
        }

        return claims;
    }

    /// <summary>
    /// Generates a JWT token string using the provided signing credentials and claims.
    /// </summary>
    /// <param name="signingCredentials">The <see cref="SigningCredentials"/> used to sign the token.</param>
    /// <param name="claims">A dictionary of claims to include in the token payload.</param>
    /// <returns>
    /// A <see cref="SecurityTokenDescriptor"/> object that defines the parameters and configuration for generating a JWT, 
    /// including issuer, audience, claims, expiration, and signing credentials.
    /// </returns>
    private SecurityTokenDescriptor GenerateTokenOptions(SigningCredentials signingCredentials, Dictionary<string, object> claims)
    {
        var jwtSettings = _configuration.GetSection("JwtSettings");

        var tokenOptions = new SecurityTokenDescriptor
        {
            Issuer = jwtSettings["ValidIssuer"],
            Audience = jwtSettings["ValidAudience"],
            Claims = claims,
            Expires = DateTime.Now.AddMinutes(Convert.ToDouble(jwtSettings["Expires"])),
            SigningCredentials = signingCredentials
        };

        return tokenOptions;
    }
}