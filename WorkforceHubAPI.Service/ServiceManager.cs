using WorkforceHubAPI.Contracts;
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

    public ServiceManager(IRepositoryManager repositoryManager, ILoggerManager logger)
    {
        _companyService = new Lazy<ICompanyService>(
            () => new CompanyService(repositoryManager, logger)
        );
        _employeeService = new Lazy<IEmployeeService>(
            () => new EmployeeService(repositoryManager, logger)
        );
    }

    /// <summary>
    /// Gets the service instance for business logic operations related to the Company entity.
    /// </summary>
    public ICompanyService CompanyService => _companyService.Value;

    /// <summary>
    /// Gets the service instance for business logic operations related to the Employee entity.
    /// </summary>
    public IEmployeeService EmployeeService => _employeeService.Value;
}
