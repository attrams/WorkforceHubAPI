using WorkforceHubAPI.Shared.DataTransferObjects;

namespace WorkforceHubAPI.Service.Contracts;

/// <summary>
/// Interface for defining business logic operations related to the Employee entity.
/// This serves as a contract for implementing Employee-related service logic.
/// </summary>
public interface IEmployeeService
{
    /// <summary>
    /// Retrieves all employees belonging to a specific company.
    /// </summary>
    /// <param name="companyId">The unique identifier of the company.</param>
    /// <param name="trackChanges">A flag indicating whether to track changes in the entity.</param>
    /// <returns>A collection of EmployeeDto representing employees of the specified company.</returns>
    IEnumerable<EmployeeDto> GetEmployees(string companyId, bool trackChanges);

    /// <summary>
    /// Retrieves a specific employee belonging to a specific company.
    /// </summary>
    /// <param name="companyId">The unique identifier of the company.</param>
    /// <param name="employeeId">The unique identifer of the employee.</param>
    /// <param name="trackChanges">A flag indicating whether to track changes in the entity.</param>
    /// <returns>An EmployeeDto representing the specified employee.</returns>
    EmployeeDto GetEmployee(string companyId, string employeeId, bool trackChanges);

    /// <summary>
    /// Creates a new employee and associates them with a specified company.
    /// </summary>
    /// <param name="companyId">The unique identify of the company to which the employee will belong to.</param>
    /// <param name="employeeForCreation">The data transfer object containing the details of the employee to be created.</param>
    /// <param name="trackChanges">A flag indicating whether to track changes on the retrieved company entity.</param>
    /// <returns>A data transfer object representing the created employee.</returns>
    EmployeeDto CreateEmployeeForCompany(string companyId, EmployeeForCreationDto employeeForCreation, bool trackChanges);
}
