using WorkforceHubAPI.Entities.Models;
using WorkforceHubAPI.Shared.DataTransferObjects;
using WorkforceHubAPI.Shared.RequestFeatures;

namespace WorkforceHubAPI.Service.Contracts;

/// <summary>
/// Interface for defining business logic operations related to the Employee entity.
/// This serves as a contract for implementing Employee-related service logic.
/// </summary>
public interface IEmployeeService
{
    /// <summary>
    /// Retrieves a collection of employee data transfer objects (DTOs) for a specific company.
    /// </summary>
    /// <param name="companyId">The unique identifier of the company for which employee data is being retrieved.</param>
    /// <param name="employeeParameters">
    /// An instance of <see cref="EmployeeParameters"/> containing pagination and filtering details for the employee query.
    /// </param>
    /// <param name="trackChanges">A flag indicating whether changes to the data should be tracked in the context.</param>
    /// <returns>
    /// A <see cref="Task{TResult}"/> representing the asynchronous operation. The result is a tuple containing:
    ///     <para>- An <see cref="IEnumerable{T}"/> of <see cref="EmployeeDto"/> entities, representing the employees on the current page.</para>
    ///     <para>- A <see cref="MetaData"/> object, which provides pagination details like total count, current page, and total pages.</para>
    /// </returns>
    /// <remarks>
    /// This method supports pagination and filtering based on the parameters provided in <paramref name="employeeParameters"/>.
    /// The query result is limited by the <see cref="EmployeeParameters.PageSize"/> and <see cref="EmployeeParameters.PageNumber"/> values.
    /// The method returns employee data in the form of <see cref="EmployeeDto"/> rather than the full <see cref="Employee"/> entities.
    /// </remarks>
    Task<(IEnumerable<EmployeeDto> employees, MetaData metaData)> GetEmployeesAsync(string companyId, EmployeeParameters employeeParameters, bool trackChanges);

    /// <summary>
    /// Retrieves a specific employee belonging to a specific company.
    /// </summary>
    /// <param name="companyId">The unique identifier of the company.</param>
    /// <param name="employeeId">The unique identifer of the employee.</param>
    /// <param name="trackChanges">A flag indicating whether to track changes in the entity.</param>
    /// <returns>An EmployeeDto representing the specified employee.</returns>
    Task<EmployeeDto> GetEmployeeAsync(string companyId, string employeeId, bool trackChanges);

    /// <summary>
    /// Creates a new employee and associates them with a specified company.
    /// </summary>
    /// <param name="companyId">The unique identify of the company to which the employee will belong to.</param>
    /// <param name="employeeForCreation">The data transfer object containing the details of the employee to be created.</param>
    /// <param name="trackChanges">A flag indicating whether to track changes on the retrieved company entity.</param>
    /// <returns>A data transfer object representing the created employee.</returns>
    Task<EmployeeDto> CreateEmployeeForCompanyAsync(string companyId, EmployeeForCreationDto employeeForCreation, bool trackChanges);

    /// <summary>
    /// Deletes an employee for a specific company. Validates the company and employee IDs, and ensure they exist before
    /// attempting to delete the employee.
    /// </summary>
    /// <param name="companyId">The ID of the company that the employee belongs to.</param>
    /// <param name="employeeId">The ID of the employee to delete.</param>
    /// <param name="trackChanges">Flag indicating whether changes to the employee entity should be tracked.</param>
    Task DeleteEmployeeForCompanyAsync(string companyId, string employeeId, bool trackChanges);

    /// <summary>
    /// Updates an existing employee for a specific company.
    /// </summary>
    /// <param name="companyId">The unique identifier of the company to which the employee belongs.</param>
    /// <param name="employeeId">The unique identifier of the employee to update.</param>
    /// <param name="employeeForUpdate">The data transfer object containing the updated employee information.</param>
    /// <param name="trackCompanyChanges">A flag indicating whether to track changes to the company's data during the update process.</param>
    /// <param name="trackEmployeeChanges">A flag indicating whether to track changes to the employee's data during the update process.</param>
    Task UpdateEmployeeForCompanyAsync(string companyId, string employeeId, EmployeeForUpdateDto employeeForUpdate, bool trackCompanyChanges, bool trackEmployeeChanges);

    /// <summary>
    /// Retrieves an employee entity and its corresponding data transfer object for partial updates.
    /// </summary>
    /// <param name="companyId">The unique identifier of the company to which the employee belongs to.</param>
    /// <param name="employeeId">The unique identifier of the employee to update.</param>
    /// <param name="trackCompanyChanges">Indicates whether to track changes to the company entity.</param>
    /// <param name="trackEmployeeChanges">Indicates whether to track changes to the employee entity.</param>
    /// <returns>A tuple containing the <see cref="EmployeeForUpdateDto"/> for the patch operation and the original <see cref="Employee"/> entity.</returns>
    Task<(EmployeeForUpdateDto employeeToPatch, Employee employeeEntity)> GetEmployeeForPatchAsync(string companyId, string employeeId, bool trackCompanyChanges, bool trackEmployeeChanges);

    /// <summary>
    /// Saves the changes made to the employee after applying the patch document.
    /// </summary>
    /// <param name="employeeToPatch">The data transfer object containing the updated employee data.</param>
    /// <param name="employeeEntity">The original employee entity.</param>
    Task SaveChangesForPatchAsync(EmployeeForUpdateDto employeeToPatch, Employee employeeEntity);
}
