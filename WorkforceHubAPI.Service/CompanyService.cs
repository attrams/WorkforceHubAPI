using AutoMapper;
using WorkforceHubAPI.Contracts;
using WorkforceHubAPI.Entities.Exceptions;
using WorkforceHubAPI.Entities.Models;
using WorkforceHubAPI.Service.Contracts;
using WorkforceHubAPI.Shared.DataTransferObjects;
using WorkforceHubAPI.Shared.RequestFeatures;

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

    /// <inheritdoc/>
    public async Task<(IEnumerable<CompanyDto> companies, MetaData metaData)> GetAllCompaniesAsync(CompanyParameters companyParameters, bool trackChanges)
    {
        var companiesWithMetaData = await _repository.Company.GetAllCompaniesAsync(companyParameters, trackChanges);
        var companiesDto = _mapper.Map<IEnumerable<CompanyDto>>(companiesWithMetaData);

        return (companies: companiesDto, metaData: companiesWithMetaData.MetaData);
    }

    /// <summary>
    /// Retrieves a specific company by its unique identifier and maps it to a data transfer object (DTO).
    /// </summary>
    /// <param name="companyId">The unique identifier of the company to retrieve.</param>
    /// <param name="trackChanges">A flag indicating whether to track changes to the retrieved entity.</param>
    /// <returns>A data transfer object (DTO) representing the company with the specified identifier.</returns>
    public async Task<CompanyDto> GetCompanyAsync(string companyId, bool trackChanges)
    {
        var parsedCompanyId = ValidateCompanyIdFormat(companyId);
        var company = await GetCompanyAndCheckIfItExists(parsedCompanyId, trackChanges);
        var companyDto = _mapper.Map<CompanyDto>(company);

        return companyDto;
    }

    /// <summary>
    /// Retrieves a collection of companies based on the provided IDs.
    /// </summary>
    /// <param name="companyIds">A collection of strings representing the IDs of the companies to retrieve.</param>
    /// <param name="trackChanges">
    /// A boolean value indicating whether changes to the entities should be tracked by the context.
    /// If set to true, the context tracks changes, otherwise it does not.
    /// </param>
    /// <returns>A collection of <see cref="CompanyDto"/> representing the retrieved companies.</returns>
    /// <exception cref="IdParametersBadRequestException">Thrown when the 'companyIds' paramter is null.</exception>
    /// <exception cref="CollectionByIdsBadRequestException">
    /// Thrown when some of the provided IDs are invalid or do not correspond to any existing companies in the database.
    /// </exception>
    public async Task<IEnumerable<CompanyDto>> GetByIdsAsync(IEnumerable<string> companyIds, bool trackChanges)
    {
        // Thrown when the company ids is null or empty.
        if (companyIds is null || !companyIds.Any())
        {
            throw new IdParametersBadRequestException();
        }

        var validGuids = new List<Guid>();
        var invalidGuids = new List<string>();

        foreach (var companyId in companyIds)
        {
            if (Guid.TryParse(companyId, out var parsedCompanyId))
            {
                validGuids.Add(parsedCompanyId);
            }
            else
            {
                invalidGuids.Add(companyId);
            }
        }

        // Thrown when the provided company ids contain invalid GUID format.
        if (invalidGuids.Any())
        {
            throw new CollectionByIdsBadRequestException();
        }

        var companyEntities = await _repository.Company.GetByIdsAsync(validGuids, trackChanges);

        // Thrown when the valid company ids contain id(s) that does not exist.
        if (validGuids.Count() != companyEntities.Count())
        {
            throw new CollectionByIdsBadRequestException();
        }

        var companiesToReturn = _mapper.Map<IEnumerable<CompanyDto>>(companyEntities);

        return companiesToReturn;
    }

    /// <summary>
    /// Creates a new company by mapping the input DTO to the company entity, saves it in the repository,
    /// and maps the saved entity back to a <see cref="CompanyDto"/> for returning.
    /// </summary>
    /// <param name="company">The data transfer object containing the company details.</param>
    /// <returns>The created company as a <see cref="CompanyDto"/>.</returns>
    public async Task<CompanyDto> CreateCompanyAsync(CompanyForCreationDto company)
    {
        var companyEntity = _mapper.Map<Company>(company);
        _repository.Company.CreateCompany(companyEntity);
        await _repository.SaveAsync();

        var companyToReturn = _mapper.Map<CompanyDto>(companyEntity);

        return companyToReturn;
    }

    /// <summary>
    /// Creates multiple companies and returns the created companies along with their IDs as a string.
    /// </summary>
    /// <param name="companyCollection">The collection of companies to be created.</param>
    /// <returns>
    /// A tuple containing:
    /// - companies: The collection of created companies as DTos.
    /// - companyIds: A comma-seperated string of the IDs of the created companies.
    /// </returns>
    /// <exception cref="CompanyCollectionBadRequestException">
    /// Thrown if the provided company collection is null or does not contain any companies.
    /// </exception>
    public async Task<(IEnumerable<CompanyDto> companies, string companyIds)> CreateCompanyCollectionAsync(IEnumerable<CompanyForCreationDto> companyCollection)
    {
        if (companyCollection is null || !companyCollection.Any())
        {
            throw new CompanyCollectionBadRequestException();
        }

        var companyEntities = _mapper.Map<IEnumerable<Company>>(companyCollection);
        foreach (var company in companyEntities)
        {
            _repository.Company.CreateCompany(company);
        }

        await _repository.SaveAsync();

        var companyCollectionToReturn = _mapper.Map<IEnumerable<CompanyDto>>(companyEntities);
        var companyIds = string.Join(",", companyCollectionToReturn.Select(company => company.Id));

        return (companies: companyCollectionToReturn, companyIds: companyIds);
    }

    /// <inheritdoc/>
    /// <exception cref="InvalidIdFormatException">Thrown if the provided company ID is not a valid GUID.</exception>
    /// <exception cref="CompanyNotFoundException">Thrown if the company with the specified ID does not exist.</exception>
    public async Task DeleteCompanyAsync(string companyId, bool trackChanges)
    {
        var parsedCompanyId = ValidateCompanyIdFormat(companyId);
        var company = await GetCompanyAndCheckIfItExists(parsedCompanyId, trackChanges);
        _repository.Company.DeleteCompany(company);
        await _repository.SaveAsync();
    }

    /// <inheritdoc/>
    /// <exception cref="InvalidIdFormatException">Thrown when the provided company ID is not a valid GUID format.</exception>
    /// <exception cref="CompanyNotFoundException">Thrown when no company is found for the provided ID.</exception>
    public async Task UpdateCompanyAsync(string companyId, CompanyForUpdateDto companyForUpdate, bool trackChanges)
    {
        var parsedCompanyId = ValidateCompanyIdFormat(companyId);
        var companyEntity = await GetCompanyAndCheckIfItExists(parsedCompanyId, trackChanges);
        _mapper.Map(companyForUpdate, companyEntity);
        await _repository.SaveAsync();
    }

    /// <summary>
    /// Retrieves a company by its ID and ensures it exists in the database.
    /// </summary>
    /// <param name="companyId">The unique identifier of the company to retrieve.</param>
    /// <param name="trackChanges"> A boolean flag indicating whether to track changes to the entity in the database context.</param>
    /// <returns>The <see cref="Company"/> entity corresponding to the given ID.</returns>
    /// <exception cref="CompanyNotFoundException">Thrown if no company is found with the specified <paramref name="companyId"/>.</exception>
    private async Task<Company> GetCompanyAndCheckIfItExists(Guid companyId, bool trackChanges)
    {
        var company = await _repository.Company.GetCompanyAsync(companyId, trackChanges) ?? throw new CompanyNotFoundException(companyId);
        return company;
    }

    /// <summary>
    /// Validates the format of a company ID string and converts it to a <see cref="Guid"/>.
    /// </summary>
    /// <param name="companyId">The unique identier of the company as a string.</param>
    /// <returns>The parsed <see cref="Guid"/> if the ID is valid.</returns>
    /// <exception cref="InvalidIdFormatException">Thrown if the provided <paramref name="companyId"/> is not a valid GUID.</exception>
    private Guid ValidateCompanyIdFormat(string companyId)
    {
        if (!Guid.TryParse(companyId, out var parsedCompanyId))
        {
            throw new InvalidIdFormatException($"The company with id: {companyId} doesn't exist.");
        }

        return parsedCompanyId;
    }
}
