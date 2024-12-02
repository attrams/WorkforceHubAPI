using WorkforceHubAPI.Contracts;

namespace WorkforceHubAPI.Repository;

/// <summary>
/// Manages the repositories and provides centralized access to user repository classes.
/// Ensures a single point of control for data persistence operations.
/// </summary>
public sealed class RepositoryManager : IRepositoryManager
{
    /// <summary>
    /// Represents the database context used for interacting with the database;
    /// </summary>
    private readonly RepositoryContext _repositoryContext;

    /// <summary>
    /// Lazily initializes the company repository to manage company-related data operations.
    /// </summary>
    private readonly Lazy<ICompanyRepository> _companyRepository;

    /// <summary>
    /// Lazily initializes the employee repository to manage employee-related data operations.
    /// </summary>
    private readonly Lazy<IEmployeeRepository> _employeeRepository;

    /// <summary>
    /// Initializes a new instance of the <see cref="RepositoryManager"/> class.
    /// </summary>
    /// <param name="repositoryContext">The database context for interacting with the database.</param>
    public RepositoryManager(RepositoryContext repositoryContext)
    {
        _repositoryContext = repositoryContext;
        _companyRepository = new Lazy<ICompanyRepository>(
            () => new CompanyRepository(repositoryContext)
        );
        _employeeRepository = new Lazy<IEmployeeRepository>(
            () => new EmployeeRepository(repositoryContext)
        );
    }

    /// <summary>
    /// Gets the company repository for managing company-related operations.
    /// </summary>
    public ICompanyRepository Company => _companyRepository.Value;

    /// <summary>
    /// Gets the employee repository for managing employee-related operations.
    /// </summary>
    public IEmployeeRepository Employee => _employeeRepository.Value;

    /// <summary>
    /// Saves all changes made in the context to the database.
    /// </summary>
    public async Task SaveAsync() => await _repositoryContext.SaveChangesAsync();
}
