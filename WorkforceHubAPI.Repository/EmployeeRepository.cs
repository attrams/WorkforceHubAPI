using WorkforceHubAPI.Contracts;
using WorkforceHubAPI.Entities.Models;

namespace WorkforceHubAPI.Repository;

/// <summary>
/// Represents the repository implementation for managing <see cref="Employee"/> entities.
/// Inherits common repository logic from <see cref="RepositoryBase{Employee}"/> and implements
/// the <see cref="IEmployeeRepository"/> interface for defining additional model-specific methods.
/// </summary>
public class EmployeeRepository : RepositoryBase<Employee>, IEmployeeRepository
{
    public EmployeeRepository(RepositoryContext repositoryContext)
        : base(repositoryContext) { }

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
    public IEnumerable<Employee> GetEmployees(Guid companyId, bool trackChanges)
    {
        return FindByCondition(
            employee => employee.CompanyId.Equals(companyId), trackChanges
        ).OrderBy(employee => employee.Name).ToList();
    }

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
    public Employee? GetEmployee(Guid companyId, Guid employeeId, bool trackChanges)
    {
        return FindByCondition(
            employee => employee.CompanyId.Equals(companyId) && employee.Id.Equals(employeeId), trackChanges
        ).SingleOrDefault();
    }

    /// <summary>
    /// Associates a new employee with a specific company and adds the employee to the database.
    /// </summary>
    /// <param name="companyId">The unique identifier of the company to which the employee will be associated.</param>
    /// <param name="employee">The employee entity to be added to the database.</param>
    public void CreateEmployeeForCompany(Guid companyId, Employee employee)
    {
        // set the companyId property of the employee entity to associate it with the given company.
        employee.CompanyId = companyId;

        // Use the base repository 'Create' method to add the employee entity to the database.
        Create(employee);
    }
}
