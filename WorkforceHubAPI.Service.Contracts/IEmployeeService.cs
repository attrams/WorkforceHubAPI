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

    /// <summary>
    /// Deletes an employee for a specific company. Validates the company and employee IDs, and ensure they exist before
    /// attempting to delete the employee.
    /// </summary>
    /// <param name="companyId">The ID of the company that the employee belongs to.</param>
    /// <param name="employeeId">The ID of the employee to delete.</param>
    /// <param name="trackChanges">Flag indicating whether changes to the employee entity should be tracked.</param>
    void DeleteEmployeeForCompany(string companyId, string employeeId, bool trackChanges);

    /// <summary>
    /// Updates an existing employee for a specific company.
    /// </summary>
    /// <param name="companyId">The unique identifier of the company to which the employee belongs.</param>
    /// <param name="employeeId">The unique identifier of the employee to update.</param>
    /// <param name="employeeForUpdate">The data transfer object containing the updated employee information.</param>
    /// <param name="trackCompanyChanges">A flag indicating whether to track changes to the company's data during the update process.</param>
    /// <param name="trackEmployeeChanges">A flag indicating whether to track changes to the employee's data during the update process.</param>
    void UpdateEmployeeForCompany(string companyId, string employeeId, EmployeeForUpdateDto employeeForUpdate, bool trackCompanyChanges, bool trackEmployeeChanges);
}
