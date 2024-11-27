using AutoMapper;
using WorkforceHubAPI.Contracts;
using WorkforceHubAPI.Entities.Exceptions;
using WorkforceHubAPI.Service.Contracts;
using WorkforceHubAPI.Shared.DataTransferObjects;

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

    // AutoMapper IMapper to perform object-to-object mapping.
    private readonly IMapper _mapper;

    public CompanyService(IRepositoryManager repository, ILoggerManager logger, IMapper mapper)
    {
        _repository = repository;
        _logger = logger;
        _mapper = mapper;
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
    public IEnumerable<CompanyDto> GetAllCompanies(bool trackChanges)
    {
        var companies = _repository.Company.GetAllCompanies(trackChanges);

        var companiesDto = _mapper.Map<IEnumerable<CompanyDto>>(companies);

        return companiesDto;
    }

    /// <summary>
    /// Retrieves a specific company by its unique identifier and maps it to a data transfer object (DTO).
    /// </summary>
    /// <param name="companyId">The unique identifier of the company to retrieve.</param>
    /// <param name="trackChanges">A flag indicating whether to track changes to the retrieved entity.</param>
    /// <returns>A data transfer object (DTO) representing the company with the specified identifier.</returns>
    public CompanyDto GetCompany(string companyId, bool trackChanges)
    {
        if (!Guid.TryParse(companyId, out var parsedId))
        {
            throw new InvalidIdFormatException($"The company with id: {companyId} doesn't exist.");
        }

        var company = _repository.Company.GetCompany(parsedId, trackChanges);

        if (company is null)
        {
            throw new CompanyNotFoundException(parsedId);
        }

        var companyDto = _mapper.Map<CompanyDto>(company);

        return companyDto;
    }
}
