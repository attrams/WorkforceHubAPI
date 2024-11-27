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
}
