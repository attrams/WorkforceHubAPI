using AutoMapper;
using WorkforceHubAPI.Contracts;
using WorkforceHubAPI.Entities.Exceptions;
using WorkforceHubAPI.Entities.Models;
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

    /// <summary>
    /// Implements the functionality to create a new employee and associate them with a specific company.
    /// </summary>
    /// <param name="companyId">The unique identifier of the company to which the employee will belong to.</param>
    /// <param name="employeeForCreation">The data transfer object containing the details of the employee to be created.</param>
    /// <param name="trackChanges">A flag indicating whether to track changes on the retrieved company entity.</param>
    /// <returns></returns>
    /// <exception cref="BadRequestException">Thrown when the <paramref name="employeeForCreation"/> is null.</exception>
    /// <exception cref="InvalidIdFormatException">Thrown when the <paramref name="companyId"/> is not in a valid format.</exception>
    /// <exception cref="CompanyNotFoundException">Thrown when the specified company is not found in the database.</exception>
    public EmployeeDto CreateEmployeeForCompany(string companyId, EmployeeForCreationDto employeeForCreation, bool trackChanges)
    {
        if (employeeForCreation is null)
        {
            throw new BadRequestException("EmployeeForCreationDto object is null.");
        }

        if (!Guid.TryParse(companyId, out var parsedCompanyId))
        {
            throw new InvalidIdFormatException($"The company with id: {companyId} doesn't exist in the database.");
        }

        var company = _repository.Company.GetCompany(parsedCompanyId, trackChanges);

        if (company is null)
        {
            throw new CompanyNotFoundException(parsedCompanyId);
        }

        var employeeEntity = _mapper.Map<Employee>(employeeForCreation);

        _repository.Employee.CreateEmployeeForCompany(parsedCompanyId, employeeEntity);
        _repository.Save();

        var employeeToReturn = _mapper.Map<EmployeeDto>(employeeEntity);

        return employeeToReturn;
    }

    /// <inheritdoc/>
    /// <exception cref="InvalidIdFormatException">
    /// Exception thrown if the <paramref name="companyId"/> or <paramref name="employeeId"/> is not in a valid format.
    /// </exception>
    /// <exception cref="CompanyNotFoundException">Exception thrown when the specified company is not found in the database.</exception>
    /// <exception cref="EmployeeNotFoundException">Exception thrown when the specified employee is not found in the database.</exception>
    public void DeleteEmployeeForCompany(string companyId, string employeeId, bool trackChanges)
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

        var employeeForCompany = _repository.Employee.GetEmployee(parsedCompanyId, parsedEmployeeId, trackChanges);
        if (employeeForCompany is null)
        {
            throw new EmployeeNotFoundException(parsedEmployeeId);
        }

        _repository.Employee.DeleteEmployee(employeeForCompany);
        _repository.Save();
    }

    /// <inheritdoc/>
    /// <exception cref="InvalidIdFormatException">Thrown when the provided company ID or employee ID is not in the correct format.</exception>
    /// <exception cref="BadRequestException">Thrown when the <see cref="EmployeeForUpdateDto"/> is null.</exception>
    /// <exception cref="CompanyNotFoundException">Thrown when the specified company cannot be found in the database.</exception>
    /// <exception cref="EmployeeNotFoundException">Thrown when the specified employee cannot be found in the database.</exception>
    public void UpdateEmployeeForCompany(string companyId, string employeeId, EmployeeForUpdateDto employeeForUpdate, bool trackCompanyChanges, bool trackEmployeeChanges)
    {
        if (!Guid.TryParse(companyId, out var parsedCompanyId))
        {
            throw new InvalidIdFormatException($"The company with id: {companyId} doesn't exist in the database.");
        }
        if (!Guid.TryParse(employeeId, out var parsedEmployeeId))
        {
            throw new InvalidIdFormatException($"The employee with id: {employeeId} doesn't exist in the database.");
        }
        if (employeeForUpdate is null)
        {
            throw new BadRequestException("EmployeeForUpdateDto is null");
        }

        var company = _repository.Company.GetCompany(parsedCompanyId, trackCompanyChanges);
        if (company is null)
        {
            throw new CompanyNotFoundException(parsedCompanyId);
        }

        var employeeEntity = _repository.Employee.GetEmployee(parsedCompanyId, parsedEmployeeId, trackEmployeeChanges);
        if (employeeEntity is null)
        {
            throw new EmployeeNotFoundException(parsedEmployeeId);
        }

        _mapper.Map(employeeForUpdate, employeeEntity);
        _repository.Save();
    }
}
