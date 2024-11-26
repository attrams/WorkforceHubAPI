using WorkforceHubAPI.Contracts;
using WorkforceHubAPI.Entities.Models;
using WorkforceHubAPI.Service.Contracts;

namespace WorkforceHubAPI.Service;

/// <summary>
/// Service class responsible for implementing business logic operations related to the Company entity.
/// Implements the <see cref="ICompanyService"/> interface.
/// </summary>
internal sealed class CompanyService : ICompanyService
{
    // Repository manager for accessing data repositories
    private readonly IRepositoryManager _repository;

    // Logger for logging messages and error.
    private readonly ILoggerManager _logger;

    public CompanyService(IRepositoryManager repository, ILoggerManager logger)
    {
        _repository = repository;
        _logger = logger;
    }

    /// <summary>
    /// Retrieves all companies from the database and handles any potential exceptions during the operation.
    /// </summary>
    /// <param name="trackChanges">
    /// A boolean flag indicating whether to track changes to the entities. If true, changes to the entities are
    /// tracked by the context. If false, entities are queried without tracking.
    /// </param>
    /// <returns>
    /// A collection of all companies in the database.
    /// </returns>
    /// <exception cref="Exception">
    /// Logs the error and rethrows it if something goes wrong during data retrieval.
    /// </exception>
    public IEnumerable<Company> GetAllCompanies(bool trackChanges)
    {
        try
        {
            var companies = _repository.Company.GetAllCompanies(trackChanges);

            return companies;
        }
        catch (Exception ex)
        {
            // Logs the error and includes context about the service method.
            _logger.LogError($"Something went wrong in the {nameof(GetAllCompanies)} service method {ex}");

            throw;
        }
    }
}
