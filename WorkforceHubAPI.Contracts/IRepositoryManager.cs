namespace WorkforceHubAPI.Contracts;

/// <summary>
/// Provides an interface to manage repositories and handle data persistence operations.
/// </summary>
public interface IRepositoryManager
{
    /// <summary>
    /// Gets the repository for accessing and managing company data.
    /// </summary>
    ICompanyRepository Company { get; }

    /// <summary>
    /// Gets the repository for accessing and managing employee data.
    /// </summary>
    IEmployeeRepository Employee { get; }

    /// <summary>
    /// Persists all changes made in the repositories to the database.
    /// </summary>
    Task SaveAsync();
}
