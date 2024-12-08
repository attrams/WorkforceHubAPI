using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using WorkforceHubAPI.Contracts;
using WorkforceHubAPI.Entities.Exceptions;
using WorkforceHubAPI.Entities.Models;
using WorkforceHubAPI.Service.Contracts;
using WorkforceHubAPI.Shared.DataTransferObjects;

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
}