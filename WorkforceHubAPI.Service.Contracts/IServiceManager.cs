namespace WorkforceHubAPI.Service.Contracts;

/// <summary>
/// Interface for the service manager which provides access to the service layer operations.
/// Serves as a centralized access point for all service classes.
/// </summary>
public interface IServiceManager
{
    /// <summary>
    /// Gets the service instance for business logic operations related to the Company entity.
    /// </summary>
    ICompanyService CompanyService { get; }

    /// <summary>
    /// Gets the service instance for business logic operations related to the Employee entity.
    /// </summary>
    IEmployeeService EmployeeService { get; }

    /// <summary>
    ///  Gets the service instance for business logic operations related to the Authentication.
    /// </summary>
    IAuthenticationService AuthenticationService { get; }
}
