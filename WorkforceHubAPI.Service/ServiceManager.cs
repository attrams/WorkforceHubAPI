using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using WorkforceHubAPI.Contracts;
using WorkforceHubAPI.Entities.Models;
using WorkforceHubAPI.Service.Contracts;

namespace WorkforceHubAPI.Service;

/// <summary>
/// Implementation of the <see cref="IServiceManager"/> interface.
/// Manages the creation and lifetime of service instances, providing access to business logic operations.
/// </summary>
public sealed class ServiceManager : IServiceManager
{
    // Lazy-loaded instance of the CompanyService
    private readonly Lazy<ICompanyService> _companyService;

    // Lazy-loaded instance of the EmployeeService
    private readonly Lazy<IEmployeeService> _employeeService;

    // Lazy-loaded instance of the AuthenticationService
    private readonly Lazy<IAuthenticationService> _authenticationService;

    public ServiceManager(
        IRepositoryManager repositoryManager,
        ILoggerManager logger,
        IMapper mapper,
        UserManager<User> userManager,
        RoleManager<IdentityRole> roleManager,
        IConfiguration configuration
    )
    {
        _companyService = new Lazy<ICompanyService>(
            () => new CompanyService(repositoryManager, logger, mapper)
        );
        _employeeService = new Lazy<IEmployeeService>(
            () => new EmployeeService(repositoryManager, logger, mapper)
        );
        _authenticationService = new Lazy<IAuthenticationService>(
            () => new AuthenticationService(logger, mapper, userManager, roleManager, configuration)
        );
    }

    /// <inheritdoc/>
    public ICompanyService CompanyService => _companyService.Value;

    /// <inheritdoc/>
    public IEmployeeService EmployeeService => _employeeService.Value;

    /// <inheritdoc/>
    public IAuthenticationService AuthenticationService => _authenticationService.Value;
}
