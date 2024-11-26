using WorkforceHubAPI.Contracts;
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
}
