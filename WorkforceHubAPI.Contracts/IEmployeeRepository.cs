using WorkforceHubAPI.Entities.Models;

namespace WorkforceHubAPI.Contracts;

/// <summary>
/// Defines a contract for a repository that manages <see cref="Employee"/> entities.
/// This interface will be implemented to add methods specific to <see cref="Employee"/> entity operations.
/// </summary>
public interface IEmployeeRepository
{
    /// <summary>
    /// Provides a method to retrieve all employees for a company using the company's identifier.
    /// </summary>
    /// <param name="companyId">The unique identifier of the company.</param>
    /// <param name="trackChanges">
    /// A boolean flag indicating whether to track changes to the entities. If true, changes to the entities
    /// are tracked by the context. If false, entities are queried without tracking.
    /// </param>
    /// <returns>
    /// A collection of all the employees with the provided company identifier.
    /// </returns>
    IEnumerable<Employee> GetEmployees(Guid companyId, bool trackChanges);

    /// <summary>
    /// Retrieves a specific employee using the provided employee identifier and company identifier.
    /// </summary>
    /// <param name="companyId">The unique identifier of the company the employee belongs to.</param>
    /// <param name="employeeId">The unique identifier of the employee</param>
    /// <param name="trackChanges">A flag indicating whether to track changes to the retrieved entity.</param>
    /// <returns>
    /// The employee entity with the specified identifier from the company with the identifier provided, or null if
    /// no match is found.
    /// </returns>
    Employee? GetEmployee(Guid companyId, Guid employeeId, bool trackChanges);

    /// <summary>
    /// Adds a new employee to the company with the specified company id.
    /// </summary>
    /// <param name="companyId">The unique identifier of the company to which the employee will belong to.</param>
    /// <param name="employee">The employee entity to be created.</param>
    void CreateEmployeeForCompany(Guid companyId, Employee employee);
}
