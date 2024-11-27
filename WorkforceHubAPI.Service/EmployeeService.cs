using AutoMapper;
using WorkforceHubAPI.Contracts;
using WorkforceHubAPI.Entities.Exceptions;
using WorkforceHubAPI.Service.Contracts;
using WorkforceHubAPI.Shared.DataTransferObjects;

namespace WorkforceHubAPI.Service;

/// <summary>
/// Service class responsible for implementing business logic operations related to the Employee entity.
/// Implements the <see cref="IEmployeeService"/> interface.
/// </summary>
internal sealed class EmployeeService : IEmployeeService
{
    // Repository manager for accessing data repositories
    private readonly IRepositoryManager _repository;

    // Logger for logging messages and errors.
    private readonly ILoggerManager _logger;

    // AutoMapper IMapper to perform object-to-object mapping.
    private readonly IMapper _mapper;

    public EmployeeService(IRepositoryManager repository, ILoggerManager logger, IMapper mapper)
    {
        _repository = repository;
        _logger = logger;
        _mapper = mapper;
    }

    /// <summary>
    /// Retrieves all employees belonging to a specific company.
    /// </summary>
    /// <param name="companyId">The unique identifier of the company.</param>
    /// <param name="trackChanges">A flag indicating whether to track changes in the entity.</param>
    /// <returns>A collection of EmployeeDto representing employees of the specified company.</returns>
    /// <exception cref="InvalidIdFormatException">Thrown when the company ID is not in a valid format.</exception>
    /// <exception cref="CompanyNotFoundException">Thrown when the company with the given ID does not exist.</exception>
    public IEnumerable<EmployeeDto> GetEmployees(string companyId, bool trackChanges)
    {
        if (!Guid.TryParse(companyId, out var parsedId))
        {
            throw new InvalidIdFormatException($"The company with id: {companyId} doesn't exist in the database.");
        }

        var company = _repository.Company.GetCompany(parsedId, trackChanges);

        if (company is null)
        {
            throw new CompanyNotFoundException(parsedId);
        }

        var employeesFromDb = _repository.Employee.GetEmployees(parsedId, trackChanges);
        var employeesDto = _mapper.Map<IEnumerable<EmployeeDto>>(employeesFromDb);

        return employeesDto;
    }

    /// <summary>
    /// Retrieves a specific employee belonging to a specific company.
    /// </summary>
    /// <param name="companyId">The unique identifier of the company.</param>
    /// <param name="employeeId">The unique identifer of the employee.</param>
    /// <param name="trackChanges">A flag indicating whether to track changes in the entity.</param>
    /// <returns>An EmployeeDto representing the specified employee.</returns>
    /// <exception cref="InvalidIdFormatException">Thrown when the company or employee ID is not in a valid format.</exception>
    /// <exception cref="CompanyNotFoundException">Thrown when the company with the given ID does not exist.</exception>
    /// <exception cref="EmployeeNotFoundException">Thrown when the employee with the given ID does not exist.</exception>
    public EmployeeDto GetEmployee(string companyId, string employeeId, bool trackChanges)
    {
        if (!Guid.TryParse(companyId, out var parsedCompanyId))
        {
            throw new InvalidIdFormatException($"The company with id: {companyId} doesn't exist in the database.");
        }

        if (!Guid.TryParse(employeeId, out var parsedEmployeeId))
        {
            throw new InvalidIdFormatException($"The employee with id: {employeeId} doesn't exist in the database.");
        }

        var company = _repository.Company.GetCompany(parsedCompanyId, trackChanges);

        if (company is null)
        {
            throw new CompanyNotFoundException(parsedCompanyId);
        }

        var employeeDb = _repository.Employee.GetEmployee(parsedCompanyId, parsedEmployeeId, trackChanges);

        if (employeeDb is null)
        {
            throw new EmployeeNotFoundException(parsedEmployeeId);
        }

        var employee = _mapper.Map<EmployeeDto>(employeeDb);

        return employee;
    }
}
