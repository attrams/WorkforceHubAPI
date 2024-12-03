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
    public async Task<IEnumerable<EmployeeDto>> GetEmployeesAsync(string companyId, bool trackChanges)
    {
        var parsedCompanyId = ValidateAndParseId(companyId, "company");

        await CheckIfCompanyExists(parsedCompanyId, trackChanges);
        var employeesFromDb = await _repository.Employee.GetEmployeesAsync(parsedCompanyId, trackChanges);
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
    public async Task<EmployeeDto> GetEmployeeAsync(string companyId, string employeeId, bool trackChanges)
    {
        var parsedCompanyId = ValidateAndParseId(companyId, "company");
        var parsedEmployeeId = ValidateAndParseId(employeeId, "employee");

        await CheckIfCompanyExists(parsedCompanyId, trackChanges);
        var employeeDb = await GetEmployeeForCompanyAndCheckIfItExists(parsedCompanyId, parsedEmployeeId, trackChanges);
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
    public async Task<EmployeeDto> CreateEmployeeForCompanyAsync(string companyId, EmployeeForCreationDto employeeForCreation, bool trackChanges)
    {
        var parsedCompanyId = ValidateAndParseId(companyId, "company");

        await CheckIfCompanyExists(parsedCompanyId, trackChanges);
        var employeeEntity = _mapper.Map<Employee>(employeeForCreation);

        _repository.Employee.CreateEmployeeForCompany(parsedCompanyId, employeeEntity);
        await _repository.SaveAsync();

        var employeeToReturn = _mapper.Map<EmployeeDto>(employeeEntity);

        return employeeToReturn;
    }

    /// <inheritdoc/>
    /// <exception cref="InvalidIdFormatException">
    /// Exception thrown if the <paramref name="companyId"/> or <paramref name="employeeId"/> is not in a valid format.
    /// </exception>
    /// <exception cref="CompanyNotFoundException">Exception thrown when the specified company is not found in the database.</exception>
    /// <exception cref="EmployeeNotFoundException">Exception thrown when the specified employee is not found in the database.</exception>
    public async Task DeleteEmployeeForCompanyAsync(string companyId, string employeeId, bool trackChanges)
    {
        var parsedCompanyId = ValidateAndParseId(companyId, "company");
        var parsedEmployeeId = ValidateAndParseId(employeeId, "employee");

        await CheckIfCompanyExists(parsedCompanyId, trackChanges);
        var employeeForCompany = await GetEmployeeForCompanyAndCheckIfItExists(parsedCompanyId, parsedEmployeeId, trackChanges);

        _repository.Employee.DeleteEmployee(employeeForCompany);
        await _repository.SaveAsync();
    }

    /// <inheritdoc/>
    /// <exception cref="InvalidIdFormatException">Thrown when the provided company ID or employee ID is not in the correct format.</exception>
    /// <exception cref="CompanyNotFoundException">Thrown when the specified company cannot be found in the database.</exception>
    /// <exception cref="EmployeeNotFoundException">Thrown when the specified employee cannot be found in the database.</exception>
    public async Task UpdateEmployeeForCompanyAsync(string companyId, string employeeId, EmployeeForUpdateDto employeeForUpdate, bool trackCompanyChanges, bool trackEmployeeChanges)
    {
        var parsedCompanyId = ValidateAndParseId(companyId, "company");
        var parsedEmployeeId = ValidateAndParseId(employeeId, "employee");

        await CheckIfCompanyExists(parsedCompanyId, trackCompanyChanges);
        var employeeEntity = await GetEmployeeForCompanyAndCheckIfItExists(parsedCompanyId, parsedEmployeeId, trackEmployeeChanges);

        _mapper.Map(employeeForUpdate, employeeEntity);
        await _repository.SaveAsync();
    }

    /// <inheritdoc/>
    /// <exception cref="InvalidIdFormatException">Thrown when the company or employee ID is not valid.</exception>
    /// <exception cref="CompanyNotFoundException">Thrown if the specified company is not found.</exception>
    /// <exception cref="EmployeeNotFoundException">Thrown if the specified employee is not found.</exception>
    public async Task<(EmployeeForUpdateDto employeeToPatch, Employee employeeEntity)> GetEmployeeForPatchAsync(string companyId, string employeeId, bool trackCompanyChanges, bool trackEmployeeChanges)
    {
        var parsedCompanyId = ValidateAndParseId(companyId, "company");
        var parsedEmployeeId = ValidateAndParseId(employeeId, "employee");

        await CheckIfCompanyExists(parsedCompanyId, trackCompanyChanges);
        var employeeEntity = await GetEmployeeForCompanyAndCheckIfItExists(parsedCompanyId, parsedEmployeeId, trackEmployeeChanges);
        var employeeToPatch = _mapper.Map<EmployeeForUpdateDto>(employeeEntity);

        return (employeeToPatch, employeeEntity);
    }

    /// <inheritdoc/>
    public async Task SaveChangesForPatchAsync(EmployeeForUpdateDto employeeToPatch, Employee employeeEntity)
    {
        _mapper.Map(employeeToPatch, employeeEntity);
        await _repository.SaveAsync();
    }

    /// <summary>
    /// Checks if a company with the specified ID exists in the database.
    /// </summary>
    /// <param name="companyId">The unique identifier of the company to check.</param>
    /// <param name="trackChanges">A boolean flag indicating whether to track changes to the entity in the database context</param>
    /// <returns>A <see cref="Task"/> representing the asynchronous operation.</returns>
    /// <exception cref="CompanyNotFoundException">Thrown if no company is found with the specified <paramref name="companyId"/>.</exception>
    private async Task CheckIfCompanyExists(Guid companyId, bool trackChanges)
    {
        _ = await _repository.Company.GetCompanyAsync(companyId, trackChanges) ?? throw new CompanyNotFoundException(companyId);
    }

    /// <summary>
    /// Retrieves an employee by their ID within a specific company and ensures the employee exists.
    /// </summary>
    /// <param name="companyId">The unique identifier of the company to which the employee belongs to.</param>
    /// <param name="employeeId">The unique identifier of the employee to retrieve.</param>
    /// <param name="trackChanges">A boolean flag indicating whether to track changes to the entity in the database context.</param>
    /// <returns>A <see cref="Task{TResult}"/> containing the <see cref="Employee"/> entity if found.</returns>
    /// <exception cref="EmployeeNotFoundException">
    /// Thrown if no employee is found with the specified <paramref name="employeeId"/> in the specified company.
    /// </exception>
    private async Task<Employee> GetEmployeeForCompanyAndCheckIfItExists(Guid companyId, Guid employeeId, bool trackChanges)
    {
        return await _repository.Employee.GetEmployeeAsync(companyId, employeeId, trackChanges) ?? throw new EmployeeNotFoundException(employeeId);
    }

    /// <summary>
    /// Validates ID and converts it to a <see cref="Guid"/>.
    /// </summary>
    /// <param name="id">The unique identifier to validate and parse.</param>
    /// <param name="entityName">
    /// A descriptive name of the entity (e.g., "company", "employee") used in the error message.
    /// </param>
    /// <returns>The parsed <paramref name="id"/> as <see cref="Guid"/> if the ID is valid.</returns>
    /// <exception cref="InvalidIdFormatException">Thrown if the provided <paramref name="id"/> is not a valid GUID.</exception>
    private Guid ValidateAndParseId(string id, string entityName)
    {
        if (!Guid.TryParse(id, out var parsedId))
        {
            throw new InvalidIdFormatException($"The {entityName} with id: {id} doesn't exist in the database.");
        }

        return parsedId;
    }
}
