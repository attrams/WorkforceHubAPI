using WorkforceHubAPI.Entities.Models;
using WorkforceHubAPI.Shared.RequestFeatures;

namespace WorkforceHubAPI.Contracts;

/// <summary>
/// Defines a contract for a repository that manages <see cref="Employee"/> entities.
/// This interface will be implemented to add methods specific to <see cref="Employee"/> entity operations.
/// </summary>
public interface IEmployeeRepository
{
    /// <summary>
    /// Retrieves a collection of employees associated with a specific company.
    /// </summary>
    /// <param name="companyId">The unique identifier of the company for which employees are being retrieved.</param>
    /// <param name="employeeParameters">An instance of <see cref="EmployeeParameters"/> containing pagination and filtering details.</param>
    /// <param name="trackChanges">A flag indicating whether changes to the data should be tracked in the context.</param>
    /// <returns>A <see cref="Task{TResult}"/> representing the asynchronous operation. The result is a <see cref="PagedList{T}"/> collection of <see cref="Employee"/> entities.</returns>
    /// <remarks>
    /// This method supports pagination and filtering based on the parameters provided in <paramref name="employeeParameters"/>.
    /// The query result is limited by the <see cref="EmployeeParameters.PageSize"/> and <see cref="EmployeeParameters.PageNumber"/> values.
    /// </remarks>
    Task<PagedList<Employee>> GetEmployeesAsync(Guid companyId, EmployeeParameters employeeParameters, bool trackChanges);

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
    Task<Employee?> GetEmployeeAsync(Guid companyId, Guid employeeId, bool trackChanges);

    /// <summary>
    /// Adds a new employee to the company with the specified company id.
    /// </summary>
    /// <param name="companyId">The unique identifier of the company to which the employee will belong to.</param>
    /// <param name="employee">The employee entity to be created.</param>
    void CreateEmployeeForCompany(Guid companyId, Employee employee);

    /// <summary>
    /// Deletes an employee from the repository.
    /// </summary>
    /// <param name="employee">The employee to delete.</param>
    void DeleteEmployee(Employee employee);
}
